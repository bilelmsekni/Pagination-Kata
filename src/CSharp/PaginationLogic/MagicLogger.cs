using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginationLogic
{
    public class LoggingFactory
    {
        private LoggingFactory()
        {
            
        }

        private static LoggingFactory _logger;

        public static LoggingFactory Instance
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new LoggingFactory();
                }
                return _logger;
            }
        }

        public MagicLogger GetMagicLogger()
        {
            return new MagicLogger();
        }

    }

    public class MagicLogger
    {
        public void StartLogging()
        {
            throw new NotImplementedException();
        }

        public void EndLogging()
        {
            throw new NotImplementedException();
        }
    }
}
