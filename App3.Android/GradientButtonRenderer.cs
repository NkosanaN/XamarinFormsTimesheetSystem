using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using App3.Controls;
using App3.Droid;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientButonStack), typeof(GradientButtonRenderer))]
namespace App3.Droid
{
    public class GradientButtonRenderer : ButtonRenderer
    {
        private Xamarin.Forms.Color StartColor { get; set; }
        private Xamarin.Forms.Color EndColor { get; set; }
        private bool RoundCorners { get; set; }
        private double CornerRadius { get; set; }

        public GradientButtonRenderer(Context context) : base(context)
        {

        }

        protected override void DispatchDraw(Canvas canvas)
        {
            var gradient = new Android.Graphics.LinearGradient(120, 0, Width, Height,
                this.StartColor.ToAndroid(),
                this.EndColor.ToAndroid(),
                Android.Graphics.Shader.TileMode.Mirror);


            var paint = new Android.Graphics.Paint()
            {
                Dither = true,
            };

            paint.SetShader(gradient);
            canvas.DrawPaint(paint);

            base.DispatchDraw(canvas);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                var btn = e.NewElement as GradientButonStack;

                var gradient = new GradientDrawable(GradientDrawable.Orientation.TopBottom, new[] {
                    btn.StartColor.ToAndroid().ToArgb(),
                    btn.EndColor.ToAndroid().ToArgb()
                });

                //gradient.SetShape(ShapeType.Rectangle);
                gradient.SetCornerRadius(50);

                Control.Background = gradient;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"   ERROR: ", ex.Message);
            }
        }
    }
}