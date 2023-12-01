/****************************************************
  文件：Command.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/29 21:22:25
  功能：Nothing
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    public interface ICommand : IBelongToArchitecture, ICanSetArchitecture, ICanGetSystem, ICanGetModel, ICanGetUtility,
        ICanSendEvent, ICanSendCommand, ICanSendQuery
    {
        void Execute();
    }

    public interface ICommand<TResult> : IBelongToArchitecture, ICanSetArchitecture, ICanGetSystem, ICanGetModel, ICanGetUtility,
        ICanSendEvent, ICanSendCommand, ICanSendQuery
    {
        TResult Execute();
    }
    
    public abstract class AbstractCommand : ICommand
    {
        private IArchitecture mArchitecture;

        IArchitecture IBelongToArchitecture.GetArchitecture() => mArchitecture;

        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture) => mArchitecture = architecture;

        void ICommand.Execute() => OnExecute();

        protected abstract void OnExecute();
    }
    
    public abstract class AbstractCommand<TResult> : ICommand<TResult>
    {
        private IArchitecture mArchitecture;

        IArchitecture IBelongToArchitecture.GetArchitecture() => mArchitecture;

        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture) => mArchitecture = architecture;

        TResult ICommand<TResult>.Execute() => OnExecute();

        protected abstract TResult OnExecute();
    }
}
