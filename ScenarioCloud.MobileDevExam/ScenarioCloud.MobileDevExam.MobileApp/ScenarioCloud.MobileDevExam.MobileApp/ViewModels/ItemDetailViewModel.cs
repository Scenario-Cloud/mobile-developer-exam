﻿using System;

using ScenarioCloud.MobileDevExam.MobileApp.Models;

namespace ScenarioCloud.MobileDevExam.MobileApp.ViewModels
{
  public class ItemDetailViewModel : BaseViewModel
  {
    public Item Item { get; set; }
    public ItemDetailViewModel(Item item = null)
    {
      Title = item?.Text;
      Item = item;
    }
  }
}
