//
// TestToolbar.cs
//
// Author: Duncan Mak  (duncan@ximian.com)
//
// Copyright (C) 2002, Duncan Mak, Ximian Inc.
//

using System;

using Gtk;
using GtkSharp;

namespace WidgetViewer {
	public class TestToolbar {

		static Window window = null;
		static Toolbar toolbar = null;
		
		public static Gtk.Window Create ()
		{
			window = new Window ("Toolbar");

			toolbar = new Toolbar ();
			toolbar.InsertStock (Stock.New, "Stock icon: New", "Toolbar/New",
					     new SignalFunc (set_small_icon), IntPtr.Zero, -1);

			toolbar.InsertStock (Stock.Open, "Stock icon: Open", "Toolbar/Open",
					     new SignalFunc (set_large_icon), IntPtr.Zero, -1);

			toolbar.AppendItem ("Horizontal", "Horizontal layout", "Toolbar/Horizontal",
					    new Image (Stock.GoForward, IconSize.LargeToolbar),
					    new SignalFunc (set_horizontal), IntPtr.Zero);

			toolbar.AppendItem ("Vertical", "Vertical layout", "Toolbar/Vertical",
					    new Image (Stock.GoUp, IconSize.LargeToolbar),
					    new SignalFunc (set_vertical), IntPtr.Zero);
			
			toolbar.AppendSpace ();

			toolbar.AppendItem ("Icons", "Only show icons", "Toolbar/IconsOnly",
					    new Image (Stock.Home, IconSize.LargeToolbar),
					    new SignalFunc (set_icon_only), IntPtr.Zero);

			toolbar.AppendItem ("Text", "Only show Text", "Toolbar/TextOnly",
					    new Image (Stock.JustifyFill, IconSize.LargeToolbar),
					    new SignalFunc (set_text_only), IntPtr.Zero);

			toolbar.AppendItem ("Both", "Show both Icon & Text", "Toolbar/Both",
					    new Image (Stock.Index, IconSize.LargeToolbar),
					    new SignalFunc (set_both), IntPtr.Zero);

			toolbar.AppendItem ("Both (Horizontal)", "Show Icon & Text horizontally", "Toolbar/BothHoriz",
					    new Image (Stock.Index, IconSize.LargeToolbar),
					    new SignalFunc (set_both_horiz), IntPtr.Zero);

			toolbar.AppendSpace ();

			toolbar.InsertStock (Stock.Close, "Stock icon: Close", "Toolbar/Close",
					     new SignalFunc (Close_Button), IntPtr.Zero, -1);

			window.Add (toolbar);
			window.ShowAll ();
			return window;
		}

		static void set_small_icon ()
		{
			Console.WriteLine ("set small icon");
			toolbar.IconSize = IconSize.SmallToolbar;
		}

		static void set_large_icon ()
		{
			Console.WriteLine ("set large icon");
			toolbar.IconSize = IconSize.LargeToolbar;
		}

		static void set_icon_only ()
		{
			Console.WriteLine ("set icon only");			
			toolbar.Style = ToolbarStyle.Icons;
		}

		static void set_text_only ()
		{
			Console.WriteLine ("set text only");
			toolbar.Style = ToolbarStyle.Text;
		}

		static void set_horizontal ()
		{
			Console.WriteLine ("set horizontal");
			toolbar.Orientation = Orientation.Horizontal;
		}

		static void set_vertical ()
		{
			Console.WriteLine ("set vertical");
			toolbar.Orientation = Orientation.Vertical;
		}
		
		static void set_both ()
		{
			Console.WriteLine ("set both");
			toolbar.Style = ToolbarStyle.Both;
		}

		static void set_both_horiz ()
		{
			Console.WriteLine ("set both horiz.");
			toolbar.Style = ToolbarStyle.BothHoriz;
		}

		static void Close_Button ()
		{
			window.Destroy ();
		}
	}
}
