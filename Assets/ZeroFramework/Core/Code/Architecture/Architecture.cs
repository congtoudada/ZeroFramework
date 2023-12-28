/****************************************************
  文件：IArchitecture.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/29 16:30:11
  功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZeroFramework
{
    public interface IArchitecture
    {
        // 注册到容器
        T RegisterSystem<T>(T system) where T : class, ISystem;
        void RegisterSystem<T>(Func<object> systemFunc) where T : class, ISystem;
        T RegisterModel<T>(T model) where T : class, IModel;
        void RegisterModel<T>(Func<object> modelFunc) where T : class, IModel;
        T RegisterUtility<T>(T utility) where T : class, IUtility;
        void RegisterUtility<T>(Func<object> utilityFunc) where T : class, IUtility;
        
        // 从容器内移除
        void UnRegisterSystem<T>() where T : ISystem;
        void UnRegisterModel<T>() where T : IModel;
        void UnRegisterUtility<T>() where T : IUtility;
        
        // 获取容器内内容
        T GetSystem<T>() where T : class, ISystem;
        T GetModel<T>() where T : class, IModel;
        T GetUtility<T>() where T : class, IUtility;
        
        // 发送命令
        void SendCommand<T>(T command) where T : ICommand;
        TResult SendCommand<TResult>(ICommand<TResult> command);
        
        // 发送查询
        TResult SendQuery<TResult>(IQuery<TResult> query);
        
        // 发送事件
        void SendEvent<T>() where T : new();
        void SendEvent<T>(T e);
        // 注册与解绑事件
        IUnRegister RegisterEvent<T>(Action<T> onEvent);
        void UnRegisterEvent<T>(Action<T> onEvent);
        void UnRegisterEvent<T>();
        
        // 销毁架构
        void Deinit();
        
        // 是否初始化
        bool Initialized { get; set; }
    }

    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        public bool Initialized { get; set; }
        private IOCTypeContainer mTypeContainer = new IOCTypeContainer();
        private IOCTypeContainer<Func<object>> mTypeFuncContainer = new IOCTypeContainer<Func<object>>();
        private ITypeEventKit mTypeEventKit = new TypeEventKit();
        
        // 类似单例实现架构类
        private static T mArchitecture;
        public static IArchitecture Interface
        {
            get
            {
                if (mArchitecture == null) MakeSureArchitecture();
                return mArchitecture;
            }
        }
    
        #region Init
        private static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();

                foreach (var model in mArchitecture.mTypeContainer.GetInstancesByType<IModel>().Where(m=>!m.Initialized))
                {
                    model.Init();
                    model.Initialized = true;
                }
                
                foreach (var system in mArchitecture.mTypeContainer.GetInstancesByType<ISystem>().Where(m=>!m.Initialized))
                {
                    system.Init();
                    system.Initialized = true;
                }
                
                mArchitecture.Initialized = true;
            }
        }

        protected abstract void Init();

        public void Deinit()
        {
            OnDeinit();
            foreach (var system in mTypeContainer.GetInstancesByType<ISystem>().Where(s=>s.Initialized)) system.Deinit();
            foreach (var model in mTypeContainer.GetInstancesByType<IModel>().Where(m=>m.Initialized)) model.Deinit();
            mTypeContainer.Clear();
            mTypeFuncContainer.Clear();
            mArchitecture = null;
            Initialized = false;
        }

        protected virtual void OnDeinit() { }
        #endregion

        #region Register
        public TSystem RegisterSystem<TSystem>(TSystem system) where TSystem : class, ISystem
        {
            if (system == null) return null;
            system.SetArchitecture(this);
            mTypeContainer.Register<TSystem>(system);

            if (Initialized)
            {
                system.Init();
                system.Initialized = true;
            }
            return system;
        }

        public void RegisterSystem<TSystem>(Func<object> systemFunc) where TSystem : class, ISystem
        {
            mTypeFuncContainer.Register<TSystem>(systemFunc);
        }

        public TModel RegisterModel<TModel>(TModel model) where TModel : class, IModel
        {
            if (model == null) return null;
            model.SetArchitecture(this);
            mTypeContainer.Register<TModel>(model);

            if (Initialized)
            {
                model.Init();
                model.Initialized = true;
            }
            return model;
        }

        public void RegisterModel<TModel>(Func<object> modelFunc) where TModel : class, IModel
        {
            mTypeFuncContainer.Register<TModel>(modelFunc);
        }

        public TUtility RegisterUtility<TUtility>(TUtility utility) where TUtility : class, IUtility
        {
            if (utility == null) return null;
            mTypeContainer.Register<TUtility>(utility);
            return utility;
        }

        public void RegisterUtility<TUtility>(Func<object> utilityFunc) where TUtility : class, IUtility
        {
            mTypeFuncContainer.Register<TUtility>(utilityFunc);
        }

        #endregion
        
        #region UnRegister
        public void UnRegisterSystem<TSystem>() where TSystem : ISystem
        {
            mTypeContainer.UnRegister<TSystem>();
            mTypeFuncContainer.UnRegister<TSystem>();
        }

        public void UnRegisterModel<TModel>() where TModel : IModel
        {
            mTypeContainer.UnRegister<TModel>();
            mTypeFuncContainer.UnRegister<TModel>();
        }

        public void UnRegisterUtility<TUtility>() where TUtility : IUtility
        {
            mTypeContainer.UnRegister<TUtility>();
            mTypeFuncContainer.UnRegister<TUtility>();
        }

        #endregion
        
        #region Get

        public TSystem GetSystem<TSystem>() where TSystem : class, ISystem
        {
            TSystem result = mTypeContainer.Get<TSystem>();
            if (result == null)
            {
                var creator = mTypeFuncContainer.Get<TSystem>();
                if (creator != null)
                {
                    result = this.RegisterSystem<TSystem>(creator() as TSystem);
                }
            }
            return result;
        }

        public TModel GetModel<TModel>() where TModel : class, IModel
        {
            TModel result = mTypeContainer.Get<TModel>();
            if (result == null)
            {
                var creator = mTypeFuncContainer.Get<TModel>();
                if (creator != null)
                {
                    result = this.RegisterModel<TModel>(creator() as TModel);
                }
            }
            return result;
        }

        public TUtility GetUtility<TUtility>() where TUtility : class, IUtility
        {
            TUtility result = mTypeContainer.Get<TUtility>();
            if (result == null)
            {
                var creator = mTypeFuncContainer.Get<TUtility>();
                if (creator != null)
                {
                    result = this.RegisterUtility<TUtility>(creator() as TUtility);
                }
            }
            return result;
        }
        
        #endregion
        
        #region Command,Query,Event
        public TResult SendCommand<TResult>(ICommand<TResult> command) => ExecuteCommand(command);

        public void SendCommand<TCommand>(TCommand command) where TCommand : ICommand => ExecuteCommand(command);

        protected virtual TResult ExecuteCommand<TResult>(ICommand<TResult> command)
        {
            command.SetArchitecture(this);
            return command.Execute();
        }

        protected virtual void ExecuteCommand(ICommand command)
        {
            command.SetArchitecture(this);
            command.Execute();
        }

        public TResult SendQuery<TResult>(IQuery<TResult> query) => DoQuery<TResult>(query);

        protected virtual TResult DoQuery<TResult>(IQuery<TResult> query)
        {
            query.SetArchitecture(this);
            return query.Do();
        }

        public void SendEvent<TEvent>() where TEvent : new() => mTypeEventKit.Send<TEvent>();

        public void SendEvent<TEvent>(TEvent e) => mTypeEventKit.Send<TEvent>(e);

        public IUnRegister RegisterEvent<TEvent>(Action<TEvent> onEvent) => mTypeEventKit.Register<TEvent>(onEvent);

        public void UnRegisterEvent<TEvent>(Action<TEvent> onEvent) => mTypeEventKit.UnRegister<TEvent>(onEvent);
        
        public void UnRegisterEvent<TEvent>() => mTypeEventKit.UnRegister<TEvent>();
        
        #endregion
    }
}
