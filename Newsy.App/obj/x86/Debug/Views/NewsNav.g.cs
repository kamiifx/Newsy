﻿#pragma checksum "C:\Users\Kamii\Documents\School\Newsy\Newsy.App\Views\NewsNav.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6A77B73ADF9FA9A86CE1546FD7F3649EADBE51ECEECF1E5A0C68B46C613E3DEC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Newsy.App.Views
{
    partial class NewsNav : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Views\NewsNav.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                }
                break;
            case 2: // Views\NewsNav.xaml line 24
                {
                    this.userEmail = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // Views\NewsNav.xaml line 37
                {
                    this.mainframe = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 4: // Views\NewsNav.xaml line 28
                {
                    this.DailyButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.DailyButton).Click += this.DailyButton_OnClick;
                }
                break;
            case 5: // Views\NewsNav.xaml line 29
                {
                    this.FavoriteButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.FavoriteButton).Click += this.FavoriteButton_OnClick;
                }
                break;
            case 6: // Views\NewsNav.xaml line 30
                {
                    this.SearchButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.SearchButton).Click += this.SearchButton_OnClick;
                }
                break;
            case 7: // Views\NewsNav.xaml line 30
                {
                    this.Search = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // Views\NewsNav.xaml line 29
                {
                    this.Favorites = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // Views\NewsNav.xaml line 28
                {
                    this.Daily = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

