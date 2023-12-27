using AutoMapper;
using MusicasApi.Data.DTOs;
using MusicasApi.Models;

namespace MusicasApi.Profiles;

public class MusicProfile : Profile
{
    public MusicProfile()
    {
        CreateMap<CreatedMusicDto, Music>();
        CreateMap<Music, ReadMusicDto>();
        CreateMap<UpdateMusicDto, Music>();
    }
}
