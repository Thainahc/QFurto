﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QFurto.Models.Enums
{
    public enum ResponseTypeEnum
    {
        None = 0, //Null
        Success = 1, //True
        Warning = 2, //False
        Error = 3, //Exception
    }
}