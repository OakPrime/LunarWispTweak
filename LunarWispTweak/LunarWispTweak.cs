using BepInEx;
using System;
using RoR2;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine;
using RoR2.CharacterAI;
using System.Linq;

namespace LunarWispTweak
{

    //This is an example plugin that can be put in BepInEx/plugins/ExamplePlugin/ExamplePlugin.dll to test out.
    //It's a small plugin that adds a relatively simple item to the game, and gives you that item whenever you press F2.

    //This attribute is required, and lists metadata for your plugin.
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]

    //This is the main declaration of our plugin class. BepInEx searches for all classes inheriting from BaseUnityPlugin to initialize on startup.
    //BaseUnityPlugin itself inherits from MonoBehaviour, so you can use this as a reference for what you can declare and use in your plugin class: https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
    public class LunarWispTweak : BaseUnityPlugin
    {
        //The Plugin GUID should be a unique ID for this plugin, which is human readable (as it is used in places like the config).
        //If we see this PluginGUID as it is on thunderstore, we will deprecate this mod. Change the PluginAuthor and the PluginName !
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "OakPrime";
        public const string PluginName = "LunarWispTweak";
        public const string PluginVersion = "1.0.0";

        //The Awake() method is run at the very start when the game is initialized.
        public void Awake()
        {
            Log.Init(Logger);
            try
            {
                RoR2Application.onLoad += () =>
                {
                    //AISkillDriver skillDriverStrafe = ((IEnumerable<AISkillDriver>)Addressables.LoadAssetAsync<GameObject>((object)"RoR2/Base/LunarWisp/LunarWispMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "Strafe")).First<AISkillDriver>();
                    //AISkillDriver skillDriverChase = ((IEnumerable<AISkillDriver>) Addressables.LoadAssetAsync<GameObject>((object)"RoR2/Base/LunarWisp/LunarWispMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "Chase")).First<AISkillDriver>();
                    AISkillDriver skillDriverBackUp = ((IEnumerable<AISkillDriver>)Addressables.LoadAssetAsync<GameObject>((object)"RoR2/Base/LunarWisp/LunarWispMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "Back Up")).First<AISkillDriver>();
                    AISkillDriver skillDriverSeekingBomb = ((IEnumerable<AISkillDriver>)Addressables.LoadAssetAsync<GameObject>((object)"RoR2/Base/LunarWisp/LunarWispMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "SeekingBomb")).First<AISkillDriver>();

                    AISkillDriver skillDriverMinigun = ((IEnumerable<AISkillDriver>)Addressables.LoadAssetAsync<GameObject>((object)"RoR2/Base/LunarWisp/LunarWispMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "Minigun")).First<AISkillDriver>();

                    /*Log.LogDebug("flee min distance: " + skillDriverFlee.minDistance);
                    Log.LogDebug("flee max distance: " + skillDriverFlee.maxDistance);
                    Log.LogDebug("approach min distance: " + skillDriverFollow.minDistance);
                    Log.LogDebug("approach max distance: " + skillDriverFollow.maxDistance);
                    Log.LogDebug("chase min distance: " + skillDriverFollowFast.minDistance);
                    Log.LogDebug("chase max distance: " + skillDriverFollowFast.maxDistance);*/
                    Log.LogDebug("shoot min distance: " + skillDriverMinigun.minDistance);
                    Log.LogDebug("shoot max distance: " + skillDriverMinigun.maxDistance);
                    Log.LogDebug("flee max distance: " + skillDriverBackUp.maxDistance);
                    Log.LogDebug("bomb min distance: " + skillDriverSeekingBomb.minDistance);
                    skillDriverMinigun.maxDistance = 70.0f;//60.0f; 75? 
                    skillDriverMinigun.minDistance = 20.0f;
                    skillDriverBackUp.maxDistance = 20.0f;
                    skillDriverSeekingBomb.minDistance = 20.0f;
                    //skillDriverMinigun.minDistance = 0.0f;
                    Log.LogDebug("new shoot min distance: " + skillDriverMinigun.minDistance);
                    Log.LogDebug("new shoot max distance: " + skillDriverMinigun.maxDistance);
                    Log.LogDebug("new flee max distance: " + skillDriverBackUp.maxDistance);
                    Log.LogDebug("new bomb min distance: " + skillDriverSeekingBomb.minDistance);

                    //skillDriverFlee.maxDistance = 15.0f;
                    //skillDriverFollow.minDistance = 30.0f;
                    //skillDriverFollowFast.minDistance = 75.0f;

                    /*Log.LogDebug("flee min distance: " + skillDriverFlee.minDistance);
                    Log.LogDebug("flee max distance: " + skillDriverFlee.maxDistance);
                    Log.LogDebug("approach min distance: " + skillDriverFollow.minDistance);
                    Log.LogDebug("approach max distance: " + skillDriverFollow.maxDistance);
                    Log.LogDebug("chase min distance: " + skillDriverFollowFast.minDistance);
                    Log.LogDebug("chase max distance: " + skillDriverFollowFast.maxDistance);*/
                };

            }
            catch (Exception e)
            {
                Logger.LogError(e.Message + " - " + e.StackTrace);
            }
        }
    }
}
