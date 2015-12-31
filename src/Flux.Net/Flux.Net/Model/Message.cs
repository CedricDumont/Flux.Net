using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.Net.Model
{
    public class Message
    {
        public Message(Author author, String text)
        {
            this.Author = author;
            this.Text = text;
        }

        public Int64 Id { get; set; }

        public Author Author { get; private set; }

        public String Text { get; private set; }


    }
}
