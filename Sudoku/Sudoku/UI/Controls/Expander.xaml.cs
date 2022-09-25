using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sudoku.UI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Expander : ContentView
    {
        public Expander()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        #region Bindable properties
        public static readonly BindableProperty ContentTemplateProperty = 
            BindableProperty.Create(
            propertyName: "ContentTemplate",
            returnType: typeof(View),
            declaringType: typeof(Expander),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay, propertyChanged : ContentTemplatePropertyChanged);

        public View ContentTemplate
        {
            get { return base.GetValue(ContentTemplateProperty) as View; }
            set { base.SetValue(ContentTemplateProperty, value); }

        }

        private static void ContentTemplatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Expander)bindable;
            control.ContentTemplate = newValue as View;
        }


        public static readonly BindableProperty IsOpenedProperty =
           BindableProperty.Create(
           propertyName: "IsOpened",
           returnType: typeof(bool),
           declaringType: typeof(Expander),
           defaultValue: false,
           defaultBindingMode: BindingMode.TwoWay, propertyChanged: IsOpenedPropertyChanged);

        public bool IsOpened
        {
            get { return (bool)base.GetValue(IsOpenedProperty); }
            set { base.SetValue(IsOpenedProperty, value); }
        }

        private static void IsOpenedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Expander)bindable;
            control.IsOpened = (bool)newValue;
        }

        #endregion

        public event EventHandler ButtonClick;

        private void Button_Tapped(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(sender, e);
            if (IsOpened)
            {
                CloseContent();
                return;
            }
            OpenContent();
        }

        public void CloseContent()
        {
            if (!IsOpened) return;
            
            contentFrame.WidthRequest = contentFrame.Width;
            var anim = new Animation(v => contentFrame.WidthRequest = v,start: contentFrame.Width, end: 10, Easing.CubicInOut);
            anim.Commit(this, "CloseContentAnimation", length:500);
            IsOpened = false;
        }
        public void OpenContent()
        {
            if (IsOpened) return;
            contentFrame.WidthRequest = contentFrame.Width;
            var anim = new Animation(v => contentFrame.WidthRequest = v, start: contentFrame.Width, end: (contentFrame.Parent.Parent.Parent as VisualElement).Width, Easing.CubicInOut);
            anim.Commit(this, "OpenContentAnimation", length: 500);
            IsOpened = true;
        }


    }
}