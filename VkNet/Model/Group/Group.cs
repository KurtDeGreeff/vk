﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VkNet.Model
{
	using System;
    using System.Diagnostics;

    using VkNet.Enums.SafetyEnums;
    using VkNet.Categories;
	using VkNet.Enums;
	using VkNet.Utils;

    /// <summary>
    /// Информация о сообществе (группе).
    /// См. описание <see href="http://vk.com/dev/fields_groups"/>.
    /// </summary>
    [DebuggerDisplay("[{Id}] {Name}")]
    [Serializable]
    public class Group
	{
		#region Стандартные поля

		/// <summary>
		/// Идентификатор сообщества.
		/// </summary>
		public ulong Id { get; set; }

		/// <summary>
		/// Название сообщества.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Короткий адрес страницы сообщества, например, apiclub. Если он не назначен, то 'club'+gid, например, club35828305.
		/// </summary>
		public string ScreenName { get; set; }

		/// <summary>
		/// Публичность группы.
		/// </summary>
		public GroupPublicity? IsClosed { get; set; }

        [NonSerialized]
        private bool _IsAdmin;
		/// <summary>
		/// Признак яляется ли текущий пользователь руководителем сообщества.
		/// </summary>
		public bool IsAdmin { get { return _IsAdmin; } set { _IsAdmin = value; } }

        [NonSerialized]
        private AdminLevel? _AdminLevel;
		/// <summary>
		/// Уровень административных полномочий текущего пользователя в сообществе (действительно, если IsAdmin = true).
		/// </summary>
		public AdminLevel? AdminLevel { get { return _AdminLevel; } set { _AdminLevel = value; } }

        [NonSerialized]
        private bool? _IsMember;
		/// <summary>
		/// Признак является ли текущий пользователь участником сообщества.
		/// </summary>
		public bool? IsMember { get { return _IsMember; } set { _IsMember = value; } }

		/// <summary>
		/// Тип сообщества.
		/// </summary>
		public GroupType Type { get; set; }

		/// <summary>
		/// Информация о ссылках на предпросмотр фотографий сообщества.
		/// </summary>
		public Previews PhotoPreviews { get; set; }

		#endregion

		#region Опциональные поля

		/// <summary>
		/// Идентификатор города, указанного в информации о сообществе. Возвращается идентификатор города, который можно использовать для 
		/// получения его названия с помощью метода <see cref="DatabaseCategory.GetCitiesById"/>. Если город не указан, возвращается 0. 
		/// </summary>
		public ulong? CityId { get; set; }

		/// <summary>
		/// Идентификатор страны, указанной в информации о сообществе. Возвращается идентификатор страны, который можно использовать для 
		/// получения ее названия с помощью метода <see cref="DatabaseCategory.GetCountriesById"/>. Если страна не указана, возвращается 0.
		/// </summary>
		public ulong? CountryId { get; set; }

		/// <summary>
		/// Место, указанное в информации о сообществе.
		/// </summary>
		public Place Place { get; set; }

		/// <summary>
		/// Текст описания сообщества. 
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Название главной вики-страницы сообщества.
		/// </summary>
		public string WikiPage { get; set; }

        [NonSerialized]
        private int? _MemberCount;
        /// <summary>
		/// Количество участников сообщества. 
		/// </summary>
		public int? MembersCount { get { return _MemberCount; } set { _MemberCount = value; } }

        [NonSerialized]
        private Counters _Counters;
		/// <summary>
		/// Счетчики сообщества.
		/// </summary>
		public Counters Counters { get { return _Counters; } set { _Counters = value; } }

		/// <summary>
		/// Время начала встречи (возвращаются только для встреч).
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// Время окончания встречи (возвращаются только для встреч).
		/// </summary>
		public DateTime? EndDate { get; set; }

        [NonSerialized]
        private bool _CanPost;
		/// <summary>
		/// Информация о том, может ли текущий пользователь оставлять записи на стене сообщества (<c>true</c> - может, <c>false</c> - не может).
		/// </summary>
		public bool CanPost { get { return _CanPost; } set { _CanPost = value; } }

        [NonSerialized]
        private bool _CanSeeAllPosts;
		/// <summary>
		/// Информация о том, разрешено видеть чужие записи на стене группы (<c>true</c> - разрешено, <c>false</c> - не разрешено).
		/// </summary>
		public bool CanSeelAllPosts { get { return _CanSeeAllPosts; } set { _CanSeeAllPosts = value; } }

        [NonSerialized]
        private bool _CanUploadDocuments;
		/// <summary>
		/// Информация о том, может ли текущий пользователь загружать документы в группу (<c>true</c>, если пользователь может 
		/// загружать документы, <c>false</c> – если не может).
		/// </summary>
		public bool CanUploadDocuments { get { return _CanUploadDocuments; } set { _CanUploadDocuments = value; } }

        [NonSerialized]
        private bool _CanCreateTopic;
		/// <summary>
		/// Информация о том, может ли текущий пользователь создать тему обсуждения в группе. 
		/// (<c>true</c>, если пользователь может создать обсуждение, <c>false</c> – если не может). 
		/// </summary>
		public bool CanCreateTopic { get { return _CanCreateTopic; } set { _CanCreateTopic = value; } }

		/// <summary>
		/// Строка состояния публичной страницы. У групп возвращается строковое значение, открыта ли группа или нет, 
		/// а у событий дата начала. 
		/// </summary>
		public string Activity { get; set; }

		/// <summary>
		/// Статус сообщества. Возвращается строка, содержащая текст статуса, расположенного на странице сообщества под его названием. 
		/// </summary>
		public string Status { get; set; }

		/// <summary>
		/// Информация из блока контактов публичной страницы.
		/// </summary>
		public Collection<Contact> Contacts { get; set; }

		/// <summary>
		/// Информация из блока ссылок сообщества.
		/// </summary>
		public Collection<ExternalLink> Links { get; set; }

        [NonSerialized]
        private ulong? _FixedPostId;
		/// <summary>
		/// Идентификатор закрепленного поста сообщества. Сам пост можно получить, используя <see cref="WallCategory.GetById(IEnumerable{KeyValuePair{long, long}})"/>,
		/// передав идентификатор в виде – {group_id}_{post_id}.
		/// </summary>
		public ulong? FixedPostId { get { return _FixedPostId; } set { _FixedPostId = value; } }

		/// <summary>
		/// Возвращает информацию о том, является ли сообщество верифицированным.
		/// </summary>
		public bool IsVerified { get; set; }

		/// <summary>
		/// Адрес сайта из поля «веб-сайт» в описании сообщества.
		/// </summary>
		public string Site { get; set; }

        [NonSerialized]
        private ulong? _InvitedBy;
		/// <summary>
		/// Идентификатор пользователя пригласившего в группу
		/// </summary>
		public ulong? InvitedBy { get { return _InvitedBy; } set { _InvitedBy = value; } }

        [NonSerialized]
        private bool _IsFavorite;
		/// <summary>
		/// Возвращается 1, если сообщество находится в закладках у текущего пользователя.
		/// </summary>
		public bool IsFavorite { get { return _IsFavorite; } set { _IsFavorite = value; } }

        [NonSerialized]
        private BanInfo _BanInfo;
		/// <summary>
		/// Информация о забанненом (добавленном в черный список) пользователе сообщества.
		/// </summary>
		public BanInfo BanInfo { get { return _BanInfo; } set { _BanInfo = value; } }
		#endregion

		#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Group FromJson(VkResponse response)
		{
			var group = new Group();

			group.Id = response["id"] ?? response["gid"];
			group.Name = response["name"];
			group.ScreenName = response["screen_name"];
			group.IsClosed = response["is_closed"];
			group.IsAdmin = response["is_admin"];
			group.AdminLevel = response["admin_level"];
			group.IsMember = response["is_member"];
			group.Type = response["type"];
			group.PhotoPreviews = response;

			// опциональные поля
			group.CityId = response.ContainsKey("city") ? response["city"]["id"] : null;
			group.CountryId = response.ContainsKey("country") ? response["country"]["id"] : null;
			group.Place = response["place"];
			group.Description = response["description"];
			group.WikiPage = response["wiki_page"];
			group.MembersCount = response["members_count"];
			group.Counters = response["counters"];
			group.StartDate = response["start_date"];
			group.EndDate = response["finish_date"] ?? response["end_date"];
			group.CanPost = response["can_post"];
			group.CanSeelAllPosts = response["can_see_all_posts"];
			group.CanUploadDocuments = response["can_upload_doc"];
			group.CanCreateTopic = response["can_create_topic"];
			group.Activity = response["activity"];
			group.Status = response["status"];
			group.Contacts = response["contacts"];
			group.Links = response["links"];
			group.FixedPostId = response["fixed_post"];
			group.IsVerified = response["verified"];
			group.Site = response["site"];
			group.InvitedBy = response["invited_by"];
			group.IsFavorite = response["is_favorite"];
			group.BanInfo = response["ban_info"];

			return group;
		}



		#endregion
	}
}