using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using SimpleTaskSystem.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskSystem.Tasks
{
    /// <summary>
    /// Represents a Task entity.
    /// 
    /// Inherits from <see cref="Entity{TPrimaryKey}"/> class (Optionally can implement <see cref="IEntity{TPrimaryKey}"/> directly).
    /// 
    /// An Entity's primary key is assumed as <see cref="int"/> as default.
    /// If it's different, we must declare it as generic parameter (as done here for <see cref="long"/>).
    /// 
    /// Implements <see cref="IHasCreationTime"/>, thus ABP sets CreationTime automatically while saving to database.
    /// Also, this helps us to use standard naming and functionality for 'creation time' of entities.
    /// </summary>
    [Table("StsTasks")]
    public class Task :Entity<long>, IHasCreationTime
    {
        [ForeignKey("AssignedPersonId")]
        public virtual Person AssignedPerson { get; set; }

        public virtual int? AssignedPersonId { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual TaskState State { get; set; }

        public Task()
        {
            CreationTime = DateTime.Now;
            State = TaskState.Active;
        }
    }
}
