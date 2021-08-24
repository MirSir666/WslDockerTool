using AutoMapper;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Models.Container;
using WslDockerTool.Net5.Models.Image;
using WslDockerTool.Net5.Models.Network;
using WslDockerTool.Net5.Models.Volume;

namespace WslDockerTool.Net5.Core
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			// 
			//CreateMap<ImageListItemModel, ImagesListResponse>()
			//	//.BeforeMap((src, dest) => src.Name = dest.RepoTags[0])
			//	//.ForMember(dst => dst.RepoTags, opt => opt.MapFrom(src => src.Name))
			//	.AfterMap((src, dest) => src.Name= dest.RepoTags[0])
			//	//.ForPath(s => s.RepoTags, opt => opt.Ignore())
			//	.ReverseMap();

			CreateMap<ImagesListResponse, ImageListItemModel>()
				.AfterMap((src, dest) => dest.Name = src.RepoTags.Any() ? src.RepoTags[0] : string.Empty);
			CreateMap<NetworkResponse, NetworkListItemModel>();
			CreateMap<VolumeResponse, VolumeListItemModel>()
				.AfterMap((src, dest) => dest.Created = DateTime.Parse(src.CreatedAt));
			CreateMap<ContainerListResponse, ContainerListItemModel>();
				//.AfterMap((src, dest) => dest.Created = DateTime.Parse(src.CreatedAt));
		}
	}
}
