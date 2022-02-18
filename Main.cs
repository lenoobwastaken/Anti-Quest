using HarmonyLib;
using MelonLoader;
using System.Reflection;

namespace anti_quest
{
    public class Main : MelonMod
    {

	    public override void OnApplicationStart()
	    {
		    try
		    {
			    InitPatch();
			    MelonLogger.Msg("[Anti Quest] Loaded Anti-Quest Mod, Enjoy! (https://github.com/xDecider)");
			    MelonLogger.Msg("My Balls itch (Frick quest users)")
		    }
		    catch
		    {
		    }
	    }
	    
	    
	    private static HarmonyMethod GetPatch(string name)
	    {
		    return new HarmonyMethod(typeof(Main).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
	    }
	    
	    private static readonly HarmonyLib.Harmony Instance = new HarmonyLib.Harmony("Nemesis");

	    private static void CreatePatch(MethodInfo TargetMethod, HarmonyMethod Before = null, HarmonyMethod After = null)
	    {
		    try
		    {
			    Instance.Patch(TargetMethod, Before, After);
		    }
		    catch (System.Exception qq)
		    {
			    MelonLogger.Error($"Failed to Patch {TargetMethod.Name} \n{qq}");
		    }
	    }

	    private static void InitPatch()
	    {
		    try
		    {
			    CreatePatch(typeof(NetworkManager).GetMethod("Method_Public_Void_Player_0"), GetPatch("PrettyGay"));
		    }
		    catch (System.Exception ex)
		    {
			    MelonLogger.Error("Error while Patching OnPlayerJoin!", ex);
		    }
	    }
	    

	    private static void PrettyGay(ref VRC.Player __0)
	    { 
		    try
		    {
			    if (__0.field_Private_APIUser_0.IsOnMobile)
			    {
				    __0.gameObject.SetActive(value: false);
				    MelonLogger.Msg("[AntiQuest] Locally Blocked Quest Player ---> " + __0.prop_APIUser_0.displayName);
			    }
		    }
		    catch
		    {
		    }
	    }
	    
	    
    }
}
