using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;

namespace TasbeehApp
{

    public partial class HudWindow : Window
    {
        private bool _isKeyPressed = false;
        private List<(string phrase, int count)> _zikrList;
        private int _currentIndex = 0;
        private int _count = 0;
        private DateTime _lastKeyPressTime = DateTime.MinValue;
private readonly TimeSpan _keyPressInterval = TimeSpan.FromMilliseconds(300);
        private readonly int _vk;
        private IntPtr _hwnd;
        private const int HOTKEY_ID_MAIN = 9000;
        private const int HOTKEY_ID_EXIT = 9001;
        private readonly DispatcherTimer _colorTimer;
        private Random _rand = new Random();

        public HudWindow(List<(string phrase, int count)> zikrList, char hotkey)
        {
            InitializeComponent();
            _zikrList = zikrList;
            _vk = char.ToUpper(hotkey);

            Loaded += HudWindow_Loaded;
            Closing += HudWindow_Closing;

            _colorTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(300)
            };
            _colorTimer.Tick += (s, e) => UpdateColor();
            _colorTimer.Start();
        }

        private void HudWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = SystemParameters.WorkArea.Width - this.Width;
            this.Top = 0;

            _hwnd = new WindowInteropHelper(this).Handle;
            var source = HwndSource.FromHwnd(_hwnd);
            source.AddHook(HwndHook);
            RegisterHotKey(_hwnd, HOTKEY_ID_MAIN, 0, (uint)_vk);
            RegisterHotKey(_hwnd, HOTKEY_ID_EXIT, 0, 0x79); // F10

            SetZikr(_currentIndex);
        }

        private void HudWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UnregisterHotKey(_hwnd, HOTKEY_ID_MAIN);
            UnregisterHotKey(_hwnd, HOTKEY_ID_EXIT);
        }

        private void SetZikr(int index)
        {
            if (index >= _zikrList.Count)
            {
                DisplayText.Text = "🎉 تم الانتهاء من جميع الأذكار";
                return;
            }

            _count = 0;
            UpdateDisplay();
        }



       private void HandleTasbeeh()
{
    var now = DateTime.Now;
    if (now - _lastKeyPressTime < _keyPressInterval)
        return;

    _lastKeyPressTime = now;

    if (_currentIndex >= _zikrList.Count)
        return;

    _count++;

    if (_count >= _zikrList[_currentIndex].count)
    {
        _currentIndex++;
        SetZikr(_currentIndex);
    }
    else
    {
        UpdateDisplay();
    }
}

        private void UpdateDisplay()
        {
            if (_currentIndex >= _zikrList.Count) return;

            var currentPhrase = _zikrList[_currentIndex].phrase;
            var total = _zikrList[_currentIndex].count;
            DisplayText.Text = $"{currentPhrase} : {_count}/{total}";
        }

      


        private void UpdateColor()
        {
            byte r = (byte)_rand.Next(180, 256);
            byte g = (byte)_rand.Next(180, 256);
            byte b = (byte)_rand.Next(180, 256);
            DisplayText.Foreground = new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
{
    if (msg == 0x0312)
    {
        int id = wParam.ToInt32();
        if (id == HOTKEY_ID_MAIN)
        {
            HandleTasbeeh();
            handled = true;
        }
        else if (id == HOTKEY_ID_EXIT)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var settings = new SettingsWindow();
                settings.Show();
                this.Close();
            });
            handled = true;
        }
    }

    return IntPtr.Zero;
}

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }

    
}
