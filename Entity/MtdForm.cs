﻿/*
    MTD OrderMaker - http://ordermaker.org
    Copyright (c) 2019 Oleg Bruev <job4bruev@gmail.com>. All rights reserved.

    This file is part of MTD OrderMaker.
    MTD OrderMaker is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see  https://www.gnu.org/licenses/.
*/


using System;
using System.Collections.Generic;

namespace Mtd.OrderMaker.Dbs.Entity
{
    public partial class MtdForm
    {
        public MtdForm()
        {          
            MtdFilter = new HashSet<MtdFilter>();
            MtdFormList = new HashSet<MtdFormList>();
            MtdFormPart = new HashSet<MtdFormPart>();
            MtdStore = new HashSet<MtdStore>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public Guid MtdCategoryId { get; set; }
        public int Sequence { get; set; }
        public bool VisibleNumber { get; set; }
        public bool VisibleDate { get; set; }

        public virtual MtdCategoryForm MtdCategoryNavigation { get; set; }
        public virtual MtdFormDesk MtdFormDesk { get; set; }
        public virtual MtdFormHeader MtdFormHeader { get; set; }
        public virtual ICollection<MtdFilter> MtdFilter { get; set; }
        public virtual ICollection<MtdFormList> MtdFormList { get; set; }
        public virtual ICollection<MtdFormPart> MtdFormPart { get; set; }
        public virtual ICollection<MtdStore> MtdStore { get; set; }
    }
}

