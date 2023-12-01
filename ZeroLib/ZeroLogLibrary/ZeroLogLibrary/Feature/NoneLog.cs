using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroFramework
{
    class NoneLog : ILogToolFeature
    {
        public void Debug(object message)
        {
        }

        public void Error(object message)
        {
        }

        public void Fatal(object message)
        {
        }

        public void Info(object message)
        {
        }

        public void Warn(object message)
        {
        }
    }
}
