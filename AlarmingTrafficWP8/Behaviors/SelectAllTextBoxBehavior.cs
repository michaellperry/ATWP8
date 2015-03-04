using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Interactivity;


namespace AlarmingTrafficWP8.Behaviors
{
    public class SelectAllTextBoxBehavior : Behavior<PhoneTextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GotFocus += new RoutedEventHandler(AssociatedObject_GotFocus);
        }

        void AssociatedObject_GotFocus(object sender, RoutedEventArgs e)
        {
            ((PhoneTextBox)sender).SelectAll();
        }
    }
}
