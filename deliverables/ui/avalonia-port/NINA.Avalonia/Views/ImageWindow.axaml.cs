using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using System;

namespace NINA.Avalonia.Views {
    public partial class ImageWindow : UserControl {
        private double zoomLevel = 1.0;
        private Point panStartPoint;
        private bool isPanning = false;

        public ImageWindow() {
            InitializeComponent();
            
            // Connect event handlers
            ZoomInButton.Click += ZoomInButton_Click;
            ZoomOutButton.Click += ZoomOutButton_Click;
            ZoomFitButton.Click += ZoomFitButton_Click;
            Zoom100Button.Click += Zoom100Button_Click;
            
            ImageViewer.PointerPressed += ImageViewer_PointerPressed;
            ImageViewer.PointerReleased += ImageViewer_PointerReleased;
            ImageViewer.PointerMoved += ImageViewer_PointerMoved;
            ImageViewer.PointerWheelChanged += ImageViewer_PointerWheelChanged;
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private void ZoomInButton_Click(object sender, RoutedEventArgs e) {
            Zoom(zoomLevel * 1.25);
        }

        private void ZoomOutButton_Click(object sender, RoutedEventArgs e) {
            Zoom(zoomLevel / 1.25);
        }

        private void ZoomFitButton_Click(object sender, RoutedEventArgs e) {
            FitToWindow();
        }

        private void Zoom100Button_Click(object sender, RoutedEventArgs e) {
            Zoom(1.0);
        }

        private void Zoom(double newZoom) {
            zoomLevel = Math.Max(0.1, Math.Min(newZoom, 10.0)); // Limit zoom between 10% and 1000%
            DisplayImage.Width = DisplayImage.Source?.Size.Width * zoomLevel ?? 0;
            DisplayImage.Height = DisplayImage.Source?.Size.Height * zoomLevel ?? 0;
            ZoomLevelText.Text = $"{zoomLevel:P0}";
        }

        private void FitToWindow() {
            if (DisplayImage.Source != null) {
                var scaleX = ImageViewer.Bounds.Width / DisplayImage.Source.Size.Width;
                var scaleY = ImageViewer.Bounds.Height / DisplayImage.Source.Size.Height;
                zoomLevel = Math.Min(scaleX, scaleY) * 0.9; // Leave some margin
                Zoom(zoomLevel);
            }
        }

        private void ImageViewer_PointerPressed(object sender, PointerPressedEventArgs e) {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed) {
                panStartPoint = e.GetPosition(ImageViewer);
                isPanning = true;
                ImageViewer.Cursor = new Cursor(StandardCursorType.Hand);
            }
        }

        private void ImageViewer_PointerReleased(object sender, PointerReleasedEventArgs e) {
            isPanning = false;
            ImageViewer.Cursor = new Cursor(StandardCursorType.Arrow);
        }

        private void ImageViewer_PointerMoved(object sender, PointerEventArgs e) {
            if (isPanning && DisplayImage.Source != null) {
                var currentPoint = e.GetPosition(ImageViewer);
                var delta = currentPoint - panStartPoint;
                
                // Scroll the viewer
                ImageViewer.Offset = new Vector(
                    Math.Max(0, ImageViewer.Offset.X - delta.X),
                    Math.Max(0, ImageViewer.Offset.Y - delta.Y)
                );
                
                panStartPoint = currentPoint;
            }
        }

        private void ImageViewer_PointerWheelChanged(object sender, PointerWheelEventArgs e) {
            var delta = e.Delta.Y;
            if (delta > 0) {
                Zoom(zoomLevel * 1.25);
            } else if (delta < 0) {
                Zoom(zoomLevel / 1.25);
            }
        }

        // Properties for binding
        public IImage Image {
            get => DisplayImage.Source;
            set {
                DisplayImage.Source = value;
                if (value != null) {
                    FitToWindow();
                }
            }
        }

        public object? ButtonHeaderContent {
            get => ButtonHeaderContentPresenter.Content;
            set => ButtonHeaderContentPresenter.Content = value;
        }
    }
}