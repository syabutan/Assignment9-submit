﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class iMovieRepository
    {
        IQueryable<MovieInfo> Movies { get; }
    }
}
