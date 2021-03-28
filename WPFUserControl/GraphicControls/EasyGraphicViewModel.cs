using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUserControl.GraphicControls
{
    public class EasyGraphicViewModel:ViewModelBase
    {
        private int _status =1;

        public int Status
        {
            get { return _status; }
            set { _status = value;
                base.RaisePropertyChanged();
            }
        }


    }
}
