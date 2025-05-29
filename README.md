# How-to-remove-click-effect-on-.Net-MAUI-Expander-SfExpander

This article illustrates removing the click effect on [.NET MAUI SfExpander](https://www.syncfusion.com/maui-controls/maui-expander). In this example, we will remove the click effect on the SfExpander.

The [SfExpander](https://help.syncfusion.com/maui/expander/getting-started) is initialized with the required properties, and a custom [Header](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Expander.SfExpander.html#Syncfusion_Maui_Expander_SfExpander_Header) layout is used instead of relying on built-in tap interaction. In this layout, an `Label` is placed inside the header and assigned a `TapGestureRecognizer`. This gesture triggers a `Command` bound from the view model to toggle the `IsExpanded` property manually. By not attaching any gestures to the rest of the header and handling expansion solely through the label tap, this setup effectively removes the default click effect and provides precise control over the expander’s behavior.

**XAML:**

 ```xml
   <ContentPage.BindingContext>
       <local:MainViewModel />
   </ContentPage.BindingContext>

   <ContentPage.Content>
       <VerticalStackLayout Padding="20">
           <syncfusion:SfExpander 
           x:Name="MyExpander"
           IsExpanded="{Binding IsExpanded}">

               <syncfusion:SfExpander.Header>
                   <Grid BackgroundColor="LightGray" Padding="10">
                       <Label Text="Tap to Expand/Collapse" FontSize="18"/>
                       <Grid.GestureRecognizers>
                           <TapGestureRecognizer Command="{Binding ToggleExpanderCommand}" />
                       </Grid.GestureRecognizers>
                   </Grid>
               </syncfusion:SfExpander.Header>

               <syncfusion:SfExpander.Content>
                   <Label Text="This is the expanded content." FontSize="16" Padding="10"/>
               </syncfusion:SfExpander.Content>
           </syncfusion:SfExpander>
       </VerticalStackLayout>
   </ContentPage.Content>
 ```

**MainPage.xaml.cs**

 ```c#
 public class MainViewModel : INotifyPropertyChanged
 {
     private bool _isExpanded;

     public bool IsExpanded
     {
         get => _isExpanded;
         set
         {
             if (_isExpanded != value)
             {
                 _isExpanded = value;
                 OnPropertyChanged();
             }
         }
     }

     public ICommand ToggleExpanderCommand { get; }

     public MainViewModel()
     {
         ToggleExpanderCommand = new Command(() =>
         {
             IsExpanded = !IsExpanded;
         });
     }

     public event PropertyChangedEventHandler? PropertyChanged;

     protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
 }
 ```

 Download the complete sample from [GitHub](https://github.com/SyncfusionExamples/How-to-remove-click-effect-on-.Net-MAUI-Expander-SfExpander)

