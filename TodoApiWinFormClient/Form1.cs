using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TodoApiWinFormClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var todoClient = new TodoClient("https://localhost:44330/",new HttpClient());

                // Gets all to-dos from the API
                var allTodos = await todoClient.GetTodoItemsAllAsync();

                richTextBox1.AppendText(nameof(allTodos)+"\n"+JsonConvert.SerializeObject(allTodos)+"\n");
                // Create a new TodoItem, and save it via the API.
                var createdTodo = await todoClient.PostTodoItemsAsync(new TodoItemDTO
                {
                    Id = 111,
                    Name = "clientTest",
                    IsComplete = false
                });
                richTextBox1.AppendText(nameof(createdTodo) + "\n" + JsonConvert.SerializeObject(createdTodo) + "\n");

                // Get a single to-do by ID
                var foundTodo = await todoClient.GetTodoItemsAsync(111);
                richTextBox1.AppendText(nameof(foundTodo) + "\n" + JsonConvert.SerializeObject(foundTodo) + "\n");
            }
            catch (Exception exception)
            {

                richTextBox1.AppendText(nameof(exception) + ":\n" + exception.Message + "\n end");

            }



        }
    }
}
