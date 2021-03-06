﻿using System;
using System.Linq;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace BbsManager
{
	public partial class App : Application
	{
		TrayIcon _tray;

		public void InitializeComponent()
		{
			_tray = new TrayIcon();
			_tray.InitializeComponents();
		}

		protected override void OnExit(ExitEventArgs e)
		{
			_tray.Dispose();
			base.OnExit(e);
		}

		[STAThreadAttribute]
		[DebuggerNonUserCodeAttribute]
		public static void Main(string[] args)
		{
			if (args.Any(x => x == "-install"))
			{
				// return from this process immediately, since it is MSI step
				Process.Start(typeof(App).Assembly.Location, "-first");
				return;
			}
			var first = args.Any(x => x == "-first");
			BbsManager.App app = new BbsManager.App();
			app.InitializeComponent();
			if(first){
				app._tray.FirstBalloon();
			}
			app.Run();
		}
	}
}

