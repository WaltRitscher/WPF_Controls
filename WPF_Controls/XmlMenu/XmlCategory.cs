using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Course.Shell
{
  public class XmlCategory
  {
    public string CategoryName { get; set; }
    public List<XmlMenu> Menus { get; set; }
  }
}
