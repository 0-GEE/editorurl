using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor_Reader;

namespace EditorURL
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() != 1)
            {
                Console.WriteLine("Please provide only the desired name of the doc and try again!");
                return;
            }

            var reader = new EditorReader();

            try
            {
                reader.FetchAll();
            }
            catch (Exception e)
            {
                Console.WriteLine($"AN ERROR OCCURRED!\n {e.Message}");
                return;
            }

            var name = args[0];

            Dictionary<HitObject, int> selectedObjs = new Dictionary<HitObject, int>();

            var allObjs = reader.hitObjects;

            int comboNum = 1;
            foreach (var hitObject in allObjs)
            {
                if (hitObject.IsNewCombo())
                {
                    comboNum = 1;
                }

                if (hitObject.IsSelected)
                {
                    selectedObjs.Add(hitObject, comboNum);
                }

                comboNum++;
            }

            var firstObj = selectedObjs.First();

            var selectedTime = firstObj.Key.StartTime;
            var timeStamp = formatTime(selectedTime);

            var comboSelection = $"({formatCombo(selectedObjs)})";

            var urlExt = timeStamp + " " + comboSelection;

            var documentName = generateHTML(urlExt);

            Console.WriteLine(commitAndPush(documentName));

            
        }

        private static string formatTime(int time)
        {
            // to be implemented

            return "";
        }

        private static string formatCombo(Dictionary<HitObject, int> hitObjects)
        {
            var retVal = "";

            foreach (var pair in hitObjects) {
                retVal += pair.Value.ToString();
                
                if (!Equals(pair, hitObjects.Last()))
                {
                    retVal += ",";

                }
            }

            return retVal;
        }

        private static string generateHTML(string ext)
        {
            // to be implemented

            var retVal = "<!DOCTYPE html>\n";

            retVal += $"<script>location.replace(\"{ext}\");</script>";

            return retVal;
        }

        private static string commitAndPush(string fileName)
        {
            // to be implemented

            return "";

        }
    }
}
