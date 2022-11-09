using System.ComponentModel;

namespace AmazonMetaUI.Core
{
    interface IObsObj
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}