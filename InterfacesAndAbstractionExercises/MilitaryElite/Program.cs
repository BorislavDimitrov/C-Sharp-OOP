using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Private> privates = new List<Private>();
            List<Soldier> soldiers = new List<Soldier>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                try
                {
                    List<string> info = input.Split().ToList();
                    string type = info[0];

                    if (type == "Private")
                    {
                        string id = info[1];
                        string firstName = info[2];
                        string lastName = info[3];
                        decimal salary = decimal.Parse(info[4]);

                        Soldier newSoldier = new Private(id, firstName, lastName, salary);
                        Private newPrivate = new Private(id, firstName, lastName, salary);
                        privates.Add(newPrivate);
                        soldiers.Add(newSoldier);
                    }
                    else if (type == "LieutenantGeneral")
                    {
                        string id = info[1];
                        string firstName = info[2];
                        string lastName = info[3];
                        decimal salary = decimal.Parse(info[4]);
                        List<string> privatesIds = info.Skip(4).ToList();
                        List<Private> privatesToAdd = new List<Private>();

                        for (int i = 0; i < privatesIds.Count; i++)
                        {
                            foreach (var privateSoldier in privates)
                            {
                                if (privatesIds[i] == privateSoldier.Id)
                                {
                                    privatesToAdd.Add(privateSoldier);
                                }
                            }
                        }
                        Soldier newSoldier = new LieutenantGeneral(id, firstName, lastName, salary, privatesToAdd.ToArray());
                        soldiers.Add(newSoldier);
                    }
                    else if (type == "Engineer")
                    {
                        string id = info[1];
                        string firstName = info[2];
                        string lastName = info[3];
                        decimal salary = decimal.Parse(info[4]);
                        string corp = info[5];
                        List<string> repairsInfo = info.Skip(6).ToList();
                        List<Repair> repairs = new List<Repair>();
                        for (int i = 0; i < repairsInfo.Count; i += 2)
                        {
                            string repairName = repairsInfo[i];
                            int repairHour = int.Parse(repairsInfo[i + 1]);
                            Repair newRepair = new Repair(repairName, repairHour);
                            repairs.Add(newRepair);
                        }
                        Soldier newSoldier = new Engineer(id, firstName, lastName, salary, corp, repairs.ToArray());
                        soldiers.Add(newSoldier);
                    }
                    else if (type == "Commando")
                    {
                        string id = info[1];
                        string firstName = info[2];
                        string lastName = info[3];
                        decimal salary = decimal.Parse(info[4]);
                        string corp = info[5];
                        List<string> missionsInfo = info.Skip(6).ToList();
                        List<Mission> missionsToAdd = new List<Mission>();
                        for (int i = 0; i < missionsInfo.Count; i += 2)
                        {
                            string missionName = missionsInfo[i];
                            string missionState = missionsInfo[i + 1];
                            if (missionState != "Finished" && missionState != "inProgress")
                            {
                                continue;
                            }
                            Mission newMission = new Mission(missionName, missionState);
                            missionsToAdd.Add(newMission);
                        }
                        Soldier newSoldier = new Commando(id, firstName, lastName, salary, corp, missionsToAdd.ToArray());
                        soldiers.Add(newSoldier);
                    }
                    else if (type == "Spy")
                    {
                        string id = info[1];
                        string firstName = info[2];
                        string lastName = info[3];
                        int code = int.Parse(info[4]);
                        Soldier newSoldier = new Spy(id, firstName, lastName, code);
                        soldiers.Add(newSoldier);
                    }
                }
                catch 
                {
                    continue;
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
