using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace AirCloudWPF
{
    public class RevealBrushExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RevealBrushExtension"/> class.
        /// </summary>
        public RevealBrushExtension()
        {
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public Color Color { get; set; } = Colors.Black;

        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        /// <value>
        /// The opacity.
        /// </value>
        public double Opacity { get; set; } = 1;

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public double Size { get; set; } = 100;

        /// <summary>
        /// When implemented in a derived class, returns an object that is provided as the value of the target property for this markup extension.
        /// </summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
        /// <returns>
        /// The object value to set on the property where the extension is applied.
        /// </returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var pvt = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            var target = pvt.TargetObject as DependencyObject;

            var bgColor = Color.FromArgb(0, this.Color.R, this.Color.G, this.Color.B);
            var brush = new RadialGradientBrush(this.Color, bgColor);
            brush.MappingMode = BrushMappingMode.Absolute;
            brush.RadiusX = this.Size;
            brush.RadiusY = this.Size;

            var opacityBinding = new Binding("Opacity")
            {
                Source = target,
                Path = new PropertyPath(PointerTracker.IsEnterProperty),
                Converter = new OpacityConverter(),
                ConverterParameter = this.Opacity
            };

            BindingOperations.SetBinding(brush, RadialGradientBrush.OpacityProperty, opacityBinding);

            var binding = new MultiBinding();
            binding.Converter = new RelativePositionConverter();
            binding.Bindings.Add(new Binding() { Source = target, Path = new PropertyPath(PointerTracker.RootObjectProperty) });
            binding.Bindings.Add(new Binding() { Source = target });
            binding.Bindings.Add(new Binding() { Source = target, Path = new PropertyPath(PointerTracker.PositionProperty) });

            BindingOperations.SetBinding(brush, RadialGradientBrush.CenterProperty, binding);
            BindingOperations.SetBinding(brush, RadialGradientBrush.GradientOriginProperty, binding);
            return brush;
        }
    }
}
