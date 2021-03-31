using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUserControl
{
    public class LoDotViewModel:ViewModelBase
    {
        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value;
                base.RaisePropertyChanged();
            }
        }

    }
}
