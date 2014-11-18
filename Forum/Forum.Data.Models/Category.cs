
namespace Forum.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Category
    {
        public Category()
        {
            this.Threads = new HashSet<Thread>();
        }

        [Key]
        [Index]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }
    }
}
