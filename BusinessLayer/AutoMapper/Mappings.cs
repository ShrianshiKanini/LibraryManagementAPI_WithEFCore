﻿using AutoMapper;
using BusinessLayer.Model;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
    
    public class Mappings:Profile
    {
        public Mappings()
        {
            CreateMap<RequestedBookDetails,RequestedBookResponse>();
            CreateMap<AuthorDetails, AuthorResponse>();
            CreateMap<GenreDetails, GenreResponse>();
            CreateMap<BookDetails, BookResponse>();
            CreateMap<ReviewDetails, ReviewResponse>();
        }
    }
}
