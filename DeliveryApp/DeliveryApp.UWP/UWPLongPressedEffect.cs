using DeliveryApp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("DeliveryApp")]
[assembly: ExportEffect(typeof(DeliveryApp.UWP.UWPLongPressedEffect), "LongPressedEffect")]
namespace DeliveryApp.UWP
{
    public class UWPLongPressedEffect : PlatformEffect
    {
        private bool _attached;

        public UWPLongPressedEffect()
        {

        }

        /// <summary>
        /// Прикрепление обработчика, необходимого для эффекта
        /// </summary>
        protected override void OnAttached()
        {
            if (!_attached)
            {
                if (Control != null)
                {
                    Control.IsHoldingEnabled = true;
                  //Control.Tapped += Tapped;
                    Control.Holding += Holding;
                }
                else
                {
                    Container.IsHoldingEnabled = true;
                  //  Container.Tapped += Tapped;
                    Container.Holding += Holding;
                }
                _attached = true;
            }
        }

        /// <summary>
        /// Отсоединение обработчика для эффекта
        /// </summary>
        protected override void OnDetached()
        {
            if (_attached)
            {
                if (Control != null)
                {
                    Control.IsHoldingEnabled = true;
                    //Control.Tapped -= Tapped;
                    Control.Holding -= Holding;
                    
                }
                else
                {
                    Container.IsHoldingEnabled = true;
                    //Container.Tapped -= Tapped;
                    Container.Holding -= Holding;
                }
                _attached = false;
            }
        }

        private void Tapped(object sender, TappedRoutedEventArgs e)
        {
            var command = LongPressedEffect.GetCommand(Element);
            command?.Execute(LongPressedEffect.GetCommandParameter(Element));
        }

        private void Holding(object sender, HoldingRoutedEventArgs e)
        {
            var command = LongPressedEffect.GetCommand(Element);
            command?.Execute(LongPressedEffect.GetCommandParameter(Element));
        }
    }
}

