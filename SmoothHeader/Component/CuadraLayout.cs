using System;
using System.Collections;
using Xamarin.Forms;
using System.Linq;

namespace SmoothHeader.Component
{
    public class CuadraLayout : Grid
    {
        public static readonly BindableProperty TemplateProperty =
            BindableProperty.Create(nameof(Template),
                                    typeof(DataTemplate),
                                    typeof(CuadraLayout), 
                                    null);
        
        public DataTemplate Template
        {
            get { return (DataTemplate)GetValue(TemplateProperty); }
            set { SetValue(TemplateProperty, value); }
        }

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(nameof(Source),
                                    typeof(IList),
                                    typeof(CuadraLayout),
                                    null,
                                    propertyChanged: OnChildrenPropertyChanged);

        public IList Source 
        { 
            get { return (IList) GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        static void OnChildrenPropertyChanged(BindableObject bindable, object oldValue, object list)
        {
            var instance = (CuadraLayout)bindable;
            instance.PopulateChildren((IList)list);
        }

        void PopulateChildren(IList list)
        {
            if (ColumnDefinitions == null || ColumnDefinitions.Count == 0)
                throw new Exception("The control is in a invalid state, make sure to set the Column && Row definitions.");

            var state = 0;

            for (var row = 0; row < list.Count / 2; row++)
            {
                for (var column = 0; column < ColumnDefinitions.Count; column++)
                {
                    var template = (View)Template.CreateContent();

                    template.Margin = new Thickness(50, 0, 0, 0);

                    var bindingContext = list[Math.Min(state, list.Count - 1)];

                    if (bindingContext == null)
                        continue;

                    template.BindingContext = bindingContext;

                    Children.Add(template, column, row);

                    state += 1;
                }
            }
        }
    }
}