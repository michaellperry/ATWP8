using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace AlarmingTrafficWP8.Helpers
{
    public class NavigationService : INavigationService
    {
        private const string QueryUriKey = "userStates";
        public event NavigatingCancelEventHandler Navigating;

        private PhoneApplicationFrame _mainFrame;

        private static Dictionary<string, object> _userStates = new Dictionary<string, object>();

        public void GoBack()
        {
            if (EnsureMainFrame() && _mainFrame.CanGoBack )
            {
                _mainFrame.GoBack();
            }
        }

        public void NavigateTo(Uri pageUri)
        {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(pageUri);
            }
            
        }

        public void NavigateTo(Uri pageUri, object state)
        {
            if (EnsureMainFrame())
            {
                Uri newUri;

                lock (_userStates)
                {
                    var id = Guid.NewGuid().ToString();
                    _userStates.Add(id, state);

                    if (pageUri.OriginalString.IndexOf("?") < 0)
                    {
                        newUri = new Uri(
                            String.Format(
                            "{0}?{1}={2}",
                            pageUri.OriginalString,
                            QueryUriKey,
                            id),
                            pageUri.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative);                        
                    }
                    else
                    {
                        newUri = new Uri(
                            String.Format(
                            "{0}&{1}={2}",
                            pageUri.OriginalString,
                            QueryUriKey,
                            id),
                            pageUri.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative);                            
                    }
                }

                NavigateTo(newUri);
            }
        }

        public static object GetAndRemoveState(IDictionary<string, string> query)
        {
            lock (_userStates)
            {
                if (query.ContainsKey(QueryUriKey ) && _userStates.ContainsKey(query[QueryUriKey]))
                {
                    var state = _userStates[query[QueryUriKey]];
                    _userStates.Remove(query[QueryUriKey]);
                    return state;
                }

                return null;
            }
        }

        private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }

            _mainFrame = Application.Current.RootVisual as PhoneApplicationFrame;

            if (_mainFrame != null)
            {
                // Could be null if the app runs inside a design tool                              

                _mainFrame.Navigating += (s, e) =>
                {
                    if (Navigating != null)
                    {
                        Navigating(s, e);
                    }
                };

                return true;
            }

            return false;

        }

    }
}
