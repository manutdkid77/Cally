## About :blue_book:
This is a sample Android and iOS app created using Xamarin Forms to demonstrate creation of a work schedule/task calendar using [ScrollViews](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/scroll-view) and [BindableLayouts](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/bindable-layouts)

## Why
A mockup was given that required very complex features :flushed:
* First column of calendar to display employee names.
* Remainning columns to display employee tasks for each day of week. These can be scrolled vertically as well as horizontally.
* The first column should not be manually scrollable but can be scrolled (Vertcically) when employee tasks column are scrolled.

## Decision :thought_balloon:
* Initial plan was to use 2 ListViews but listviews dont support horizontal and verticall scrolling at the same time. Also `ScrollTo` method of ListView doesn't support scrolling via X,Y coordinates distance.
* Decided to use 2 scrollviews which can embed `StackLayouts` having an `ItemSource` property. Thank you [andreinitescu](https://github.com/andreinitescu)
* Display the employee names column within the first scrollview.
* Mark the `IsEnabled` property of first scrollview as `false`, to disable manual scrolling
* Display the employee tasks/scehdules within second scrollview. When this scrollview is scrolled, use the [`ScrollTo`](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/scroll-view#methods) method to scroll the first scrollview.
* Have use the awesome [PrismLib](https://github.com/PrismLibrary/Prism) for binding the `StackLayouts` :muscle:

## Visual Studio Requirements :rocket:
### Visual Studio for Mac
This solution requires Visual Studio for Mac 2017 or 2019.
### Visual Studio for PC
This solution requires Visual Studio for PC 2017 or 2019.