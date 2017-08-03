using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EliteMMO.API;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Shadow
{
    public partial class Shadow : Form
    {
        #region UI
        public Shadow()
        {
            InitializeComponent();
        }

        private void Shadow_Load(object sender, EventArgs e)
        {
            PopulateCombos();
            checkFollow.CheckedChanged += (s, a) => { follow = checkFollow.Checked; };
            checkAttack.CheckedChanged += (s, a) => { attack = checkAttack.Checked; };
            checkSpectral.CheckedChanged += (s, a) => { spectral = checkSpectral.Checked; };
            checkWhm.CheckedChanged += (s, a) => { whm = checkWhm.Checked; };
            checkCancel.CheckedChanged += (s, a) => { cancel = checkCancel.Checked; };
            checkMount.CheckedChanged += (s, a) => { mount = checkMount.Checked; };
            textMount.TextChanged += (s, a) => { mountName = textMount.Text; };
            checkInteractions.CheckedChanged += (s, a) => { interactions = checkInteractions.Checked; };
            checkMenuFollow.CheckedChanged += (s, a) => { menufollow = checkMenuFollow.Checked; };
            checkRed.CheckedChanged += (s, a) => { red = checkRed.Checked; };
            checkBlue.CheckedChanged += (s, a) => { blue = checkBlue.Checked; };
            SlaveNavThread.Start();
            SlaveThread.Start();
            timer1.Start();
        }

        private void PopulateCombos(object sender = null, EventArgs e = null)
        {
            if (sender == null)
            {
                comboMaster.Items.AddRange(Process.GetProcessesByName("pol").Select(a => a.MainWindowTitle).ToArray());
                comboSlave.Items.AddRange(Process.GetProcessesByName("pol").Select(a => a.MainWindowTitle).ToArray());
            }
            else
            {
                ComboBox combo = (ComboBox)sender;
                combo.Text = "";
                combo.Items.Clear();
                combo.Items.AddRange(Process.GetProcessesByName("pol").Where(a => a.MainWindowTitle != comboMaster.Text && a.MainWindowTitle != comboSlave.Text).Select(a => a.MainWindowTitle).ToArray());
            }
        }

        private void comboMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            master = new EliteAPI(Process.GetProcessesByName("pol").First(a => a.MainWindowTitle == comboMaster.Text).Id);
        }

        private void comboSlave_SelectedIndexChanged(object sender, EventArgs e)
        {
            slave = new EliteAPI(Process.GetProcessesByName("pol").First(a => a.MainWindowTitle == comboSlave.Text).Id);
        }

        private void Shadow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SlaveNavThread.Abort();
            SlaveThread.Abort();
        }
        #endregion UI

        static EliteAPI slave;
        static EliteAPI master;

        #region Helpful Functions
        static bool CheckItem(EliteAPI api, string name)
        {
            for (int i = 0; i < api.Inventory.GetContainerMaxCount(0); i++)
            {
                if (api.Inventory.GetContainerItem(0, i).Id != 0 && api.Resources.GetItem(api.Inventory.GetContainerItem(0, i).Id).Name.First() == name) return true;
            }
            return false;
        }

        static string pyxis = "";
        static Dictionary<uint, DateTime> grayList = new Dictionary<uint, DateTime>();
        public static EliteAPI.XiEntity Box(EliteAPI api)
        {
            TargetInfo TargetInfo = new TargetInfo(api);
            for (var x = 0; x < 2048; x++)
            {
                EliteAPI.XiEntity entity = api.Entity.GetEntity(x);
                if (entity.WarpPointer == 0 || entity.HealthPercent == 0 || entity.TargetID <= 0)
                    continue;
                if (entity.Distance < 10 && entity.Name == "Sturdy Pyxis") pyxis = entity.Face + " " + entity.Render0000; 
                if (entity.Distance < 10 && entity.Name == "Sturdy Pyxis" && (!grayList.ContainsKey(entity.TargetID) || grayList[entity.TargetID] < DateTime.Now))
                {
                    if (entity.Face == 965 && blue) return entity;
                    if (entity.Face == 968 && red) return entity;
                }
            }
            return null;
        }

        private static string Windower(EliteAPI api)
        {
            Process proc = Process.GetProcessesByName("pol").First(a => a.MainWindowTitle == api.Player.Name);
            for (int i = 0; i < proc.Modules.Count; i++)
            {
                if (proc.Modules[i].FileName.Contains("Ashita.dll"))
                {
                    return "Ashita";
                }
                else if (proc.Modules[i].FileName.Contains("Hook.dll"))
                {
                    return "Windower";
                }
            }
            return "";
        }

        #endregion

        static bool follow = false;
        static bool attack = false;
        static bool spectral = false;
        static bool whm = false;
        static bool cancel = false;
        static bool mount = false;
        static string mountName = "Raptor";
        static bool interactions = false;
        static bool menufollow = false;
        static bool blue = false;
        static bool red = false;
        static bool gold = false;

        static Thread SlaveNavThread = new Thread(() => SlaveNavDoWork());
        static void SlaveNavDoWork()
        {
            Queue<point> followqueue = new Queue<point>();
            bool zoneAttempt = false;

            while (1 == 1)
            {
                if (slave == null || master == null) continue;

                PlayerInfo PlayerInfo = new PlayerInfo(slave);
                TargetInfo TargetInfo = new TargetInfo(slave);
                Movement Movement = new Movement(slave);
                Recast Recast = new Recast(slave);

                System.Threading.Thread.Sleep(100);

                if (slave.Player.Status == 0)
                {
                    if (Box(slave) != null && CheckItem(slave, "Forbidden Key"))
                    {
                        if (TargetInfo.ID != Box(slave).TargetID)
                        {
                            TargetInfo.SetTarget((int)Box(slave).TargetID);
                            continue;
                        }
                        else if (TargetInfo.Distance > 3)
                        {
                            Movement.Move(Box(slave));
                            continue;
                        }
                        else
                        {
                            Movement.Stop();
                            slave.ThirdParty.SendString("item \"Forbidden Key\" <t>");
                            if (!grayList.ContainsKey(Box(slave).TargetID))
                                grayList.Add(Box(slave).TargetID, DateTime.Now.AddSeconds(20));
                            else
                                grayList[Box(slave).TargetID] = DateTime.Now.AddSeconds(20);
                            Thread.Sleep(1500);
                            continue;
                        }
                    }
                }

                switch (master.Player.Status)
                {
                    case 85:
                    case 0:
                    case 4:
                    case 33:
                        if (master.Player.ZoneId != slave.Player.ZoneId && follow)
                        {
                            if (!zoneAttempt)
                            {
                                slave.ThirdParty.KeyDown(EliteMMO.API.Keys.W);
                                Thread.Sleep(1000);
                                slave.ThirdParty.KeyUp(EliteMMO.API.Keys.W);
                                zoneAttempt = true;
                            }
                        }
                        else
                        {
                            zoneAttempt = false;
                        }
                        if (slave.Player.Status == 1 && attack)
                        {
                            slave.ThirdParty.SendString("/attackoff");
                            continue;
                        }
                        if (master.Player.Status == 85 && slave.Player.Status != 85 && mount)
                        {
                            slave.ThirdParty.SendString("/mount " + mountName);
                            continue;
                        }
                        if (master.Player.Status != 85 && slave.Player.Status == 85 && mount)
                        {
                            slave.ThirdParty.SendString("/dismount");
                            continue;
                        }
                        followqueue.Enqueue(new point(master.Player.X, master.Player.Y, master.Player.Z, master.Player.ZoneId));

                        if (follow)
                        {
                            if (followqueue.Count > 15)
                            {
                                point approach = followqueue.Dequeue();
                                float dX = approach.x - slave.Player.X;
                                float dY = approach.y - slave.Player.Y;
                                float dZ = approach.z - slave.Player.Z;
                                float distance = (float)Math.Abs(Math.Sqrt(dX * dX + dY * dY + dZ * dZ));
                                if (distance > .3 &&
                                    approach.zoneID == slave.Player.ZoneId &&
                                    !PlayerInfo.Casting)
                                {
                                    slave.AutoFollow.SetAutoFollowCoords(dX, dY, dZ);
                                    slave.AutoFollow.IsAutoFollowing = true;
                                }
                                else
                                {
                                    if (approach.zoneID == slave.Player.ZoneId) slave.AutoFollow.IsAutoFollowing = false;
                                }
                            }
                            else
                            {
                                slave.AutoFollow.IsAutoFollowing = false;
                            }
                        }
                        else
                        {
                            if (followqueue.Count > 15)
                            {
                                followqueue.Dequeue();
                            }
                        }

                        if (!PlayerInfo.HasBuff(71) && new PlayerInfo(master).HasBuff(71) && whm)
                        {
                            if (spectral)
                            {
                                slave.ThirdParty.SendString("/ja \"Spectral Jig\" <me>");
                                Thread.Sleep(1000);
                            }
                            if (whm)
                            {
                                slave.ThirdParty.SendString("/ma \"Sneak\" <me>");
                                Thread.Sleep(6000);
                            }
                        }

                        if (!PlayerInfo.HasBuff(69) && new PlayerInfo(master).HasBuff(69))
                        {
                            if (spectral)
                            {
                                slave.ThirdParty.SendString("/ja \"Spectral Jig\" <me>");
                                Thread.Sleep(1000);
                            }
                            if (whm)
                            {
                                slave.ThirdParty.SendString("/ma \"Invisible\" <me>");
                                Thread.Sleep(6000);
                            }
                        }
                        if (!new PlayerInfo(master).HasBuff(69) && PlayerInfo.HasBuff(69) && cancel)
                        {
                            if (Windower(slave) == "Windower") slave.ThirdParty.SendString("//cancel 69");
                            if (Windower(slave) == "Ashita") slave.ThirdParty.SendString("/cancel Invisible");
                        }
                        if (!new PlayerInfo(master).HasBuff(71) && PlayerInfo.HasBuff(71) && cancel)
                        {
                            if (Windower(slave) == "Windower") slave.ThirdParty.SendString("//cancel 71");
                            if (Windower(slave) == "Ashita") slave.ThirdParty.SendString("/cancel Sneak");
                        }

                        break;
                    case 1:
                        if (slave.Target.GetTargetInfo().TargetIndex != master.Target.GetTargetInfo().TargetIndex && attack)
                        {
                            slave.Target.SetTarget((int)master.Target.GetTargetInfo().TargetIndex);
                            continue;
                        }
                        if (slave.Player.Status == 0 && attack)
                        {
                            slave.ThirdParty.SendString("/attack <t>");
                            continue;
                        }
                        List<EliteAPI.XiEntity> Entity = new List<EliteAPI.XiEntity>();
                        for (var x = 0; x < 2048; x++)
                        {
                            EliteAPI.XiEntity entity = slave.Entity.GetEntity(x);
                            if (entity.HealthPercent == 0 || entity.TargetID <= 0)
                                continue;
                            var vertdiff = Math.Abs((PlayerInfo.Y - entity.Y));
                            if (vertdiff >= 2) continue;

                            if (entity.Distance < 5) Entity.Add(entity);
                        }

                        EliteAPI.XiEntity target = slave.Entity.GetEntity((int)master.Target.GetTargetInfo().TargetIndex);

                        float tX = target.X - slave.Player.X;
                        float tY = target.Y - slave.Player.Y;
                        float tZ = target.Z - slave.Player.Z;
                        if (attack)
                        {
                            if (target.Distance > 2 && !PlayerInfo.Casting && !Entity.Any(a => a.Name == "Moogle"))
                            {
                                slave.AutoFollow.SetAutoFollowCoords(tX, tY, tZ);
                                slave.AutoFollow.IsAutoFollowing = true;
                                continue;
                            }
                            else
                            {
                                slave.AutoFollow.IsAutoFollowing = false;
                            }

                            if (!TargetInfo.IsFacingTarget(PlayerInfo.X, PlayerInfo.Z, PlayerInfo.H, TargetInfo.X, TargetInfo.Z)
                                && TargetInfo.HPP > 1
                                && !PlayerInfo.Casting)
                                TargetInfo.FaceTarget(TargetInfo.X, TargetInfo.Z);
                        }
                        break;
                }
            }
        }

        static Thread SlaveThread = new Thread(() => SlaveDoWork());
        static void SlaveDoWork()
        {
            int idle = 0;
            int sleep = 500;

            while (1 == 1)
            {
                if (slave == null || master == null) continue;

                PlayerInfo PlayerInfo = new PlayerInfo(slave);
                TargetInfo TargetInfo = new TargetInfo(slave);
                PartyInfo PartyInfo = new PartyInfo(slave);
                Recast Recast = new Recast(slave);

                System.Threading.Thread.Sleep(sleep);

                if (master.Player.Status == 0 || master.Player.Status == 4)
                {
                    if (master.Player.Status == 4 && slave.Player.Status != 4 && interactions)
                    {
                        slave.Target.SetTarget((int)master.Target.GetTargetInfo().TargetIndex);
                        Thread.Sleep(1000);
                        slave.ThirdParty.KeyPress(EliteMMO.API.Keys.RETURN);
                        Thread.Sleep(2000);
                        continue;
                    }

                    if (slave.Menu.MenuName != "") idle = 0;
                    if (master.Menu.MenuName == "menu    query   " && slave.Menu.MenuName == "" && menufollow)
                    {
                        if (slave.Target.GetTargetInfo().TargetId != master.Target.GetTargetInfo().TargetId)
                        {
                            slave.Target.SetTarget((int)master.Target.GetTargetInfo().TargetIndex);
                            continue;
                        }
                        if (idle > 0)
                        {
                            slave.ThirdParty.KeyPress(EliteMMO.API.Keys.RETURN);
                            idle = 0;
                            continue;
                        }
                        else
                        {
                            idle++;
                        }
                    }

                    sleep = 10;
                    if (TargetInfo.Name != "Riftworn Pyxis" && menufollow)
                    {
                        if (slave.Player.Status == 4 && master.Player.Status == 0)
                        {
                            slave.ThirdParty.KeyPress(EliteMMO.API.Keys.ESCAPE);
                            sleep = 300;
                            continue;
                        }
                        if (master.Dialog.DialogOptionCount > 0 && slave.Dialog.DialogOptionCount > 0)
                        {
                            if (slave.Dialog.DialogId != master.Dialog.DialogId)
                            {
                                slave.ThirdParty.KeyPress(EliteMMO.API.Keys.RETURN);
                                continue;
                            }
                        }
                        if (master.Dialog.DialogOptionCount == 0 && slave.Dialog.DialogOptionCount > 0)
                        {
                            slave.ThirdParty.KeyPress(EliteMMO.API.Keys.RETURN);
                            sleep = 300;
                            continue;
                        }

                        if (slave.Dialog.DialogOptionCount > 0 && master.Dialog.DialogIndex > slave.Dialog.DialogIndex)
                        {
                            slave.ThirdParty.KeyPress(EliteMMO.API.Keys.DOWN);
                            continue;
                        }
                        if (slave.Dialog.DialogOptionCount > 0 && master.Dialog.DialogIndex < slave.Dialog.DialogIndex)
                        {
                            slave.ThirdParty.KeyPress(EliteMMO.API.Keys.UP);
                            continue;
                        }

                        if (master.Dialog.DialogOptionCount > 0) continue;
                    }

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pyxis != "")
            {
                listBox1.Items.Insert(0, pyxis);
            }
        }
    }


    public struct point
    {
        public float x, y, z;
        public int zoneID;
        public point(float X, float Y, float Z, int ZoneID)
        {
            x = X;
            y = Y;
            z = Z;
            zoneID = ZoneID;
        }
    }

    #region class: PlayerInfo
    public class PlayerInfo
    {
        EliteAPI api;
        public PlayerInfo(EliteAPI _api)
        {
            api = _api;
        }
        float lastCastPercent = 1;
        public bool Casting
        {
            get
            {
                if (api.CastBar.Percent == 1)
                {
                    return false;
                }
                if (api.CastBar.Percent != lastCastPercent)
                {
                    lastCastPercent = api.CastBar.Percent;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public int Status => (int)api.Entity.GetLocalPlayer().Status;
        public string Name => api.Party.GetPartyMembers().First().Name;
        public int HPP => api.Party.GetPartyMembers().First().CurrentHPP;
        public int MPP => api.Party.GetPartyMembers().First().CurrentMPP;
        public uint HP => api.Party.GetPartyMembers().First().CurrentHP;
        public uint MP => api.Party.GetPartyMembers().First().CurrentMP;
        public uint MaxHP => api.Player.HPMax;
        public uint MaxMP => api.Player.MPMax;
        public int TP => (int)api.Party.GetPartyMembers().First().CurrentTP;
        public int MainJob => api.Player.GetPlayerInfo().MainJob;
        public int MainJobLevel => api.Player.GetPlayerInfo().MainJobLevel;
        public int SubJob => api.Player.GetPlayerInfo().SubJob;
        public int SubJobLevel => api.Player.GetPlayerInfo().SubJobLevel;
        public bool HasBuff(short id) => api.Player.GetPlayerInfo().Buffs.Any(b => b == id);
        public int HasBuffcount(short id) => api.Player.GetPlayerInfo().Buffs.Where(b => b == id).Count();
        public bool HasAbility(uint id) => api.Player.HasAbility(id);
        public bool HasAbility(string name)
        {
            return api.Player.HasAbility(api.Resources.GetAbility(name, 0).ID);
        }

        public bool HasSpell(uint id) => api.Player.HasSpell(id);
        public bool HasSpell(string name)
        {
            return api.Player.HasSpell(api.Resources.GetSpell(name, 0).Index);
        }
        public bool HasBlueMagicSpellSet(int id) => api.Player.HasBlueMagicSpellSet(id);
        public bool HasWeaponSkill(uint id) => api.Player.HasWeaponSkill(id);
        public int ServerID => (int)api.Entity.GetLocalPlayer().ServerID;
        public int TargetID => (int)api.Entity.GetLocalPlayer().TargetID;
        public float X => api.Entity.GetLocalPlayer().X;
        public float Y => api.Entity.GetLocalPlayer().Y;
        public float Z => api.Entity.GetLocalPlayer().Z;
        public float H => api.Entity.GetLocalPlayer().H;
        public bool HasKeyItem(uint id) => api.Player.HasKeyItem(id);
        public int MeritPoints => api.Player.GetPlayerInfo().MeritPoints;
        public int UsedJobPoints => api.Player.GetJobPoints(MainJob).SpentJobPoints;
        public int UseableJobPoints => api.Player.GetJobPoints(MainJob).JobPoints;
        public int CapacityPoints => api.Player.GetJobPoints(MainJob).CapacityPoints;
        public double GetAngleFrom(double x, double z)
        {
            var angleInDegrees = (Math.Atan2(Z - z,
                X - x) * 180 / Math.PI) * -1;
            return (Math.Floor(angleInDegrees * (10 ^ 0) + 0.5) / (10 ^ 0));
        }
        public bool DynaZone()
        {
            List<int> DynaZones = new List<int>(new int[] { 39, 40, 41, 42, 134, 135, 185, 186, 187, 188 });
            if (DynaZones.Contains(api.Player.ZoneId)) return true;
            else return false;
        }
        public string DynaTime()
        {
            string vtz = "Morning";
            uint vanahour = api.VanaTime.CurrentHour;
            if (vanahour >= 0 && vanahour < 8) vtz = "Morning";
            else if (vanahour >= 8 && vanahour < 16) vtz = "Noon";
            else if (vanahour >= 16 && vanahour < 24) vtz = "Night";
            return vtz;
        }
        //public bool DynaStrike(string typ, string time, string target)
        //{
        //    if (!PlayerInfo.DynaZone()) return true;
        //    if (target == "Nightmare Taurus") return true;
        //    else if (NoProcDynaMobs.Contains(target)) return NoneProc;
        //    else if (DynaMobProc[time][typ].Contains(target)) return true;
        //    return false;
        //}
        public int GetFinishingMoves()
        {
            var retVal = 0;
            if (HasBuff(381)) { retVal = 1; }
            else if (HasBuff(382)) { retVal = 2; }
            else if (HasBuff(383)) { retVal = 3; }
            else if (HasBuff(384)) { retVal = 4; }
            else if (HasBuff(385)) { retVal = 5; }
            else if (HasBuff(588)) { retVal = 6; }
            return retVal;
        }
    }
    #endregion
    #region class: TargetInfo
    public class TargetInfo
    {
        EliteAPI api;
        public TargetInfo(EliteAPI _api)
        {
            api = _api;
        }

        public void Attack()
        {
            var count = 0;

            while (new PlayerInfo(api).Status == 0)
            {
                new WindowInfo(api).SendText("/attack <t>");
                Thread.Sleep(TimeSpan.FromSeconds(3.0));

                if (new PlayerInfo(api).Status == 1 || count == 2)
                    break;

                count = count + 1;
                Thread.Sleep(TimeSpan.FromSeconds(1.0));
            }
        }
        public string Name => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Name;
        public int ID => (int)api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).TargetID;
        public int HPP => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).HealthPercent;
        public double Distance => Math.Truncate((10 * api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance) / 10);
        public bool LockedOn => api.Target.GetTargetInfo().LockedOn;
        public float X => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).X;
        public float Y => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Y;
        public float Z => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Z;
        public float H => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).H;
        public void SetTarget(int ID) => api.Target.SetTarget(ID);
        public int GetTargetIdByName(string name)
        {
            for (var x = 0; x < 2048; x++)
            {
                var ID = api.Entity.GetEntity(x);

                if (ID.Name != null && ID.Name.ToLower().Equals(name.ToLower()))
                    return (int)ID.TargetID;
            }
            return -1;
        }
        public int GetTargetIndexByName(string name)
        {
            for (var x = 0; x < 2048; x++)
            {
                var ID = api.Entity.GetEntity(x);

                if (ID.Name != null && ID.Name.ToLower().Equals(name.ToLower()))
                    return (int)ID.ServerID;
            }
            return -1;
        }
        public void FaceTarget(float x, float z)
        {
            if (ID == new PlayerInfo(api).ServerID || ID == 0)
                return;

            var p = api.Entity.GetLocalPlayer();
            var angle = (byte)(Math.Atan((z - p.Z) / (x - p.X)) * -(128.0f / Math.PI));

            if (p.X > x)
                angle += 128;

            var radian = (((float)angle) / 255) * 2 * Math.PI;
            api.Entity.SetEntityHPosition(api.Entity.LocalPlayerIndex, (float)radian);
        }
        public bool IsFacingTarget(float x1, float z1, float h1, float x2, float z2)
        {
            var angle = GetDifferenceAngle(x1, z1, x2, z2);
            var rotation = ((h1 / (2 * 3.14159265359f)) * 255);
            return Math.Abs((angle - rotation) + -128.0f) < 20;
        }
        private float GetDifferenceAngle(float x1, float z1, float x2, float z2)
        {
            var angle = Math.Atan((z2 - z1) / (x2 - x1));
            angle *= -(128.0f / 3.14159265359f);
            return (float)(x2 > x1 ? angle + 128 : angle);
        }
    }
    #endregion
    #region class: RecastInfo
    public class Recast
    {
        EliteAPI api;
        public Recast(EliteAPI _api)
        {
            api = _api;
        }

        public int GetSpellRecast(int id) => api.Recast.GetSpellRecast(id);
        public int GetSpellRecast(string name) => api.Recast.GetSpellRecast(api.Resources.GetSpell(name, 0).Index);
        public int GetAbilityRecast(int id)
        {
            var IDs = api.Recast.GetAbilityIds();
            for (var x = 0; x < IDs.Count; x++)
            {
                if (IDs[x] == id)
                    return api.Recast.GetAbilityRecast(x);
            }
            return 0;
        }
        public int GetAbilityRecast(string name)
        {
            var IDs = api.Recast.GetAbilityIds();
            for (var x = 0; x < IDs.Count; x++)
            {
                if (IDs[x] == (int)api.Resources.GetAbility(name, 0).TimerID)
                    return api.Recast.GetAbilityRecast(x);
            }
            return 0;
        }

    }
    #endregion
    #region class: WindowInfo
    public class WindowInfo
    {
        EliteAPI api;
        public WindowInfo(EliteAPI _api)
        {
            api = _api;
        }

        public void SendText(string text) => api.ThirdParty.SendString(text);
        public void KeyPress(EliteMMO.API.Keys key) => api.ThirdParty.KeyPress(key);
        public void KeyUp(EliteMMO.API.Keys key) => api.ThirdParty.KeyUp(key);
        public void KeyDown(EliteMMO.API.Keys key) => api.ThirdParty.KeyDown(key);
    }
    #endregion
    #region class: PartyInfo
    public class PartyInfo
    {
        EliteAPI api;
        public PartyInfo(EliteAPI _api)
        {
            api = _api;
        }

        public int Count(int PartyNumber = 0)
        {
            var allience = api.Party.GetAllianceInfo();
            var pc = 0;
            if (PartyNumber == 1 || PartyNumber == 0)
                pc = pc + allience.Party0Count;
            if (PartyNumber == 2 || PartyNumber == 0)
                pc = pc + allience.Party1Count;
            if (PartyNumber == 3 || PartyNumber == 0)
                pc = pc + allience.Party2Count;
            return pc;
        }
        public bool ContainsName(string name)
        {
            foreach (var member in api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList())
            {
                if (Regex.Replace(member.Name, "([A-Z])", " $1", RegexOptions.Compiled).Trim() == name)
                    return true;
            }
            return false;
        }

        public bool ContainsID(uint ID)
        {
            foreach (var member in api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList())
            {
                if (member.ID == ID)
                    return true;
            }
            return false;
        }
        public int averageHPP()
        {
            int hpp = 0;
            var members = api.Party.GetPartyMembers().Where(p => p.Active != 0).ToList();
            foreach (var member in members)
            {
                if (member.Active != 0)
                    hpp = (hpp + member.CurrentHPP);
            }
            return (int)Math.Round((double)(hpp / members.Count));
        }
        public bool lowMP(uint val)
        {
            List<EliteAPI.PartyMember> members = api.Party.GetPartyMembers().Where(p => p.Active != 0 && p.Name == "Kupipi").ToList();
            foreach (EliteAPI.PartyMember member in members)
            {
                if (member.Name != new PlayerInfo(api).Name && member.CurrentMPP < val)
                {
                    return true;
                }
            }
            return false;

        }
    }
    #endregion
    #region class: PetInfo
    public class PetInfo
    {
        EliteAPI api;
        public PetInfo(EliteAPI _api)
        {
            api = _api;
        }

        public string Name
        {
            get
            {
                var p = api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).Name;

                return p != null
                    ? Regex.Replace(api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).Name, "([A-Z])", " $1",
                        RegexOptions.Compiled).Trim() : null;
            }
        }
        public int ID => (int)api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).ServerID;
        public int HPP => api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).HealthPercent;
        public int MPP => api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).ManaPercent;
        public int TPP => (int)api.Player.PetTP;
        public int Status => (int)api.Entity.GetEntity(api.Entity.GetLocalPlayer().PetIndex).Status;
    }
    #endregion
    #region class: Inventory
    public class Inventory
    {
        EliteAPI api;
        public Inventory(EliteAPI _api)
        {
            api = _api;
        }

        public int ItemQuantityByName(string name)
        {
            var count = api.Inventory.GetContainerCount(0);
            var itemc = 0;

            for (var x = 0; x < count; x++)
            {
                var item = api.Inventory.GetContainerItem(0, x);
                if (item.Id != 0 && api.Resources.GetItem(item.Id).Name[0] == name)
                {
                    itemc = itemc + (int)item.Count;
                }
            }
            return itemc;
        }
    }
    #endregion
    #region Movement
    public class Movement
    {
        EliteAPI api;
        public Movement(EliteAPI _api)
        {
            api = _api;
        }

        float lastX;
        float lastY;
        float lastZ;
        public bool Moving = false;
        public bool Stuck = false;
        public bool HomeStuck = false;

        public void Move(EliteAPI.XiEntity Target)
        {
            if (Target == null) return;
            if (Moving)
            {
                float dX = lastX - api.Player.X;
                float dY = lastY - api.Player.Y;
                float dZ = lastZ - api.Player.Z;
                double distance = Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
                if (distance < .1) Stuck = true;
            }

            float tX = Target.X - api.Player.X;
            float tY = Target.Y - api.Player.Y;
            float tZ = Target.Z - api.Player.Z;

            api.AutoFollow.SetAutoFollowCoords(tX, tY, tZ);
            api.AutoFollow.IsAutoFollowing = true;

            lastX = api.Player.X;
            lastY = api.Player.Y;
            lastZ = api.Player.Z;
            HomeStuck = false;
            Moving = true;
        }
        public void Stop()
        {
            Moving = false;
            api.AutoFollow.IsAutoFollowing = false;
        }

        public void Move(float X, float Y, float Z)
        {
            float tX = X - api.Player.X;
            float tY = Y - api.Player.Y;
            float tZ = Z - api.Player.Z;

            api.AutoFollow.SetAutoFollowCoords(tX, tY, tZ);
            api.AutoFollow.IsAutoFollowing = true;

            lastX = api.Player.X;
            lastY = api.Player.Y;
            lastZ = api.Player.Z;
        }
    }

    #endregion


}
