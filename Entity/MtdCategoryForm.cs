/*
    MTD OrderMaker - http://ordermaker.org
    Copyright (c) 2019 Oleg Bruev <job4bruev@gmail.com>. All rights reserved.

*/

using System;
using System.Collections.Generic;

namespace Mtd.OrderMaker.Dbs.Entity
{
    public partial class MtdCategoryForm
    {
        public MtdCategoryForm()
        {
            MtdForm = new HashSet<MtdForm>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ParentId { get; set; }

        public virtual ICollection<MtdForm> MtdForm { get; set; }
    }
}
