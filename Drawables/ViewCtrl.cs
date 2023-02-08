using Microsoft.Maui.Graphics;
using System.Diagnostics;
using SkiaSharp;
using Microsoft.Maui.Controls;
using System.Reflection;

namespace App2.Controls;


public class ViewCtrl : ScrollView
{
    private GraphicsView graphics_view_ = null;
    private ViewDrawable drawable_ = null;
    private StackLayout layout_ = null;

    public ViewCtrl()
    {
        graphics_view_ = new GraphicsView();
        drawable_ = new ViewDrawable();
        graphics_view_.Drawable = drawable_;
        layout_ = new StackLayout();
        Content = layout_;
        layout_.Children.Add(graphics_view_);
#pragma warning disable CS0618 // 类型或成员已过时
        this.VerticalOptions = LayoutOptions.FillAndExpand;
        this.HorizontalOptions = LayoutOptions.FillAndExpand;
    }
    
    public void Render()
    {
        if (drawable_ != null && graphics_view_ != null)
        {
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("App2.Resources.Images.dotnet_bot.png"))
            {
                drawable_.SetData(stream);
                graphics_view_.WidthRequest = 2500;
                graphics_view_.HeightRequest = 3000;
                graphics_view_.Invalidate();
            }
        }
    }

}
