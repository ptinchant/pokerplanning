using AutoMapper;
using PokerPlanning.Models.Model;
using PokerPlanning.Models.RequestModel;
using PokerPlanning.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerPlanning.CrossCutting
{
    public class Profiler<S, D> where S : class where D : class
    {
        MapperConfiguration configuration;
        Mapper mapper;

        public Profiler()
        {
            configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Room, RoomResponseModel>()
                        .ForMember(s => s.RoomId, d => d.MapFrom(src => src.RoomId))
                        .ForMember(s => s.RoomName, d => d.MapFrom(src => src.RoomName));

                cfg.CreateMap<RoomRequestModel, Room>()
                        .ForMember(s => s.RoomId, d => d.MapFrom(src => src.RoomId))
                        .ForMember(s => s.RoomName, d => d.MapFrom(src => src.RoomName));

            });
            mapper = new Mapper(configuration);
        }

        public D Convert(S source)
        {
            if (source == null)
                return null;
            D result = mapper.DefaultContext.Mapper.Map<D>(source);
            return result;
        }

        public IEnumerable<D> Convert(IEnumerable<S> source)
        {
            if (source == null)
                return null;

            List<D> result = (List<D>)Activator.CreateInstance(typeof(List<D>));

            foreach (S item in source)
            {
                result.Add(mapper.DefaultContext.Mapper.Map<D>(item));
            }

            return result;
        }
    }
}
