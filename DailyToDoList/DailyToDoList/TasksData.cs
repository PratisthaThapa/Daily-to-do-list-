using System;
namespace DailyToDoList
{
    public class TasksData
    {




        public void ReadTasks ()
        {

            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                //List<dict> items = JsonConvert.DeserializeObject<List<dict>>(json);
            }
        }

	}

}

