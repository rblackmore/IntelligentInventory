namespace EFCoreSetup.Menu;

internal class MenuOption
{
  public MenuOption(string name, Func<Task> callBack)
  {
    this.Name = name;
    this.CallBack = callBack;
  }

  public string Name { get; set; }

  public Func<Task> CallBack { get; set; }

  public override string ToString()
  {
    return this.Name;
  }

}
