namespace Orca.AAS
{
    public static class OrcaAAS 
    { 
        public static void RenewCurrentDrive()
        {
            Status.current_drive = "Drive";
        }
        public static void RenewCurrentPath()
        {
            Status.current_path = ["Users", "San"];
        }
    }
}