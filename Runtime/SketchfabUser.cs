/// <summary>
/// used to store the info about a single
/// sketchfab user attributed as artist of a sketchfab model
/// </summary>
public class SketchfabUser
{
    public string UserName { get; set; }
    public string ProfileURL { get; set; }
    public string Account { get; set; }
    public string DisplayName { get; set; }
    public string Uid { get; set; }
    public string Uri { get; set; }


    public override string ToString()
    {
        return $"UserName: {UserName}\n" +
               $"ProfileURL: {ProfileURL}\n" +
               $"Account: {Account}\n" +
               $"DisplayName: {DisplayName}\n" +
               $"Uid: {Uid}\n" +
               $"Uri: {Uri}\n";
    }
}