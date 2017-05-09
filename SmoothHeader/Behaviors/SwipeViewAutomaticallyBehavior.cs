using System;
using Xamarin.Forms;

namespace Behaviors
{
	public class SwipeViewAutomaticallyBehavior : Behavior<View>
	{
		View _attachedView;

		public static readonly BindableProperty ScrollDataProperty = 
			BindableProperty.Create(nameof(ScrollData),
				typeof(double),
				typeof(SwipeViewAutomaticallyBehavior), default(double),
						propertyChanged: OnScrollDataChanged);

		public double ScrollData
		{
			get { return (double) GetValue(ScrollDataProperty); }
			set { SetValue(ScrollDataProperty, value); }
		}

		static void OnScrollDataChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var instance = (SwipeViewAutomaticallyBehavior)bindable;
			instance.ScrollTo((double)newValue);
		}

		void ScrollTo(double newValue)
		{
			var xCalculation = (newValue * -1);

			_attachedView.TranslateTo(xCalculation, 0, 1, Easing.SinIn);
		}

		public SwipeViewAutomaticallyBehavior()
		{
		}

		protected override void OnAttachedTo(View bindable)
		{
			base.OnAttachedTo(bindable);

			this._attachedView = bindable;

			bindable.BindingContextChanged += OnAttachedViewBindingContextChanged;;
		}

		protected override void OnDetachingFrom(View bindable)
		{
			base.OnDetachingFrom(bindable);

			this._attachedView.BindingContextChanged -= OnAttachedViewBindingContextChanged;
		}

		void OnAttachedViewBindingContextChanged (object sender, EventArgs e)
		{
			BindingContext = _attachedView.BindingContext;
		}
	}
}
