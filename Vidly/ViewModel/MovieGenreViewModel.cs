﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieGenreViewModel
    {
        public Movie Movie { get; set; }
        public MovieGenre MovieGenre { get; set; }
    }
}