using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace AirCloudWPF
{
    /// <summary>
    /// The UI extensions class
    /// </summary>
    public static class UIExtensions
    {
        /// <summary>
        /// Gets the type of the child of.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The matching child</returns>
        public static T GetChildOfType<T>(this DependencyObject dependencyObject) where T : DependencyObject
        {
            if (dependencyObject == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                var child = VisualTreeHelper.GetChild(dependencyObject, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }

            return null;
        }

        /// <summary>
        /// Finds the child.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj">The dependency object.</param>
        /// <param name="childName">Name of the child.</param>
        /// <returns>The element</returns>
        public static T FindChild<T>(this DependencyObject depObj, string childName) where T : DependencyObject
        {
            if (depObj == null) { return null; }

            if (depObj is T && ((FrameworkElement)depObj).Name == childName)
            {
                return depObj as T;
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                T obj = FindChild<T>(child, childName);
                if (obj != null)
                {
                    return obj;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the data grid column header.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="reference">The reference.</param>
        /// <returns>The data grid column header</returns>
        public static DataGridColumnHeader GetDataGridColumnHeader(this DataGridColumn column, DependencyObject reference)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(reference); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(reference, i);

                DataGridColumnHeader colHeader = child as DataGridColumnHeader;
                if ((colHeader != null) && (colHeader.Column == column))
                {
                    return colHeader;
                }

                colHeader = GetDataGridColumnHeader(column, child);
                if (colHeader != null)
                {
                    return colHeader;
                }
            }

            return null;
        }

        public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject parent) where T : DependencyObject
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                var childType = child as T;
                if (childType != null)
                {
                    yield return (T)child;
                }

                foreach (var other in FindVisualChildren<T>(child))
                {
                    yield return other;
                }
            }
        }

        public static IEnumerable<T> FindLogicalChildren<T>(this DependencyObject parent) where T : DependencyObject
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            var queue = new Queue<DependencyObject>(new[] { parent });

            while (queue.Any())
            {
                var reference = queue.Dequeue();
                var children = LogicalTreeHelper.GetChildren(reference);
                var objects = children.OfType<DependencyObject>();

                foreach (var o in objects)
                {
                    if (o is T child)
                        yield return child;

                    queue.Enqueue(o);
                }
            }
        }
    }
}
