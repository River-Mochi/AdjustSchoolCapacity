// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleVI.cs
// Vietnamese (vi-VN) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleVI : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocaleVI(ASCSetting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ShortName;

            // Include the current mod version in the Options title.
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {
                // Mod name in options
                { m_Setting.GetSettingsLocaleID(), title },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(ASCSetting.ActionsTab), "Thao tác" },
                { m_Setting.GetOptionTabLocaleID(ASCSetting.AboutTab),   "Giới thiệu" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.CapacityGroup), "Sức chứa học sinh" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "Học phí" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "Thông tin" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "Liên kết hỗ trợ" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "Tiểu học" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**Trường tiểu học** – tùy chỉnh sức chứa bằng thanh trượt.\n" +
                    "100% = sức chứa mặc định của trò chơi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "Trung học" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**Trường trung học** – tùy chỉnh sức chứa bằng thanh trượt.\n" +
                    "100% = sức chứa mặc định của trò chơi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "Cao đẳng" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**Cao đẳng** – tùy chỉnh sức chứa bằng thanh trượt.\n" +
                    "100% = sức chứa mặc định của trò chơi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "Đại học" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**Đại học** – tùy chỉnh sức chứa bằng thanh trượt.\n" +
                    "100% = sức chứa mặc định của trò chơi."
                },

                // Capacity preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "Đặt lại về mặc định" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "Đưa tất cả thanh trượt sức chứa về 100% (mặc định của trò chơi)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "Thiết lập nhanh" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "Áp dụng thiết lập nhanh:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // School fees
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)), "Học phí giáo dục" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFF giữ nguyên học phí giáo dục thông thường của trò chơi.\n" +
                    "ON cho phép ASC kiểm soát các mức phí toàn thành phố bên dưới. Tắt tùy chọn này sẽ khôi phục mức phí mặc định của trò chơi.\n" +
                    "Mức phí âm sẽ trả trợ cấp cho tất cả hộ gia đình có học sinh hoặc sinh viên đang theo học và làm giảm ngân sách thành phố.\n" +
                    "Điều này có thể giảm áp lực tài chính cho các gia đình nghèo và hạn chế việc chuyển đi. Trong phiên bản này, mọi hộ gia đình đều áp dụng cùng một mức phí.\n" +
                    "Đây không phải là tiền miễn phí hoặc tiền được tạo ra một cách kỳ diệu.\n" +
                    "Hộ gia đình nhận tiền; ngân quỹ thành phố mất doanh thu trong cùng hạng mục.\n" +
                    "**------------------**\n" +
                    "<100%: học phí mặc định>\n" +
                    "<0%: hộ gia đình không phải trả gì.>\n" +
                    "<-20%: hộ gia đình nhận trợ cấp bằng 20% học phí mặc định.>\n" +
                    "<200%: gấp đôi học phí mặc định>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)), "Học phí tiểu học" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "<100% = học phí mặc định (100).>\n" +
                    "<0% = miễn phí> Không khoản tiền nào bị trừ khỏi hộ gia đình.\n" +
                    "**Từ -5% đến -20%** trả trợ cấp trong thời gian theo học."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)), "Học phí trung học" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "<100% = học phí mặc định (200).>\n" +
                    "<0% = miễn phí> Không khoản tiền nào bị trừ khỏi hộ gia đình.\n" +
                    "**Từ -5% đến -20%** trả trợ cấp trong thời gian theo học."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)), "Học phí cao đẳng + đại học" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "Cao đẳng và Đại học dùng chung một mức học phí trong trò chơi.\n" +
                    "<100% = học phí mặc định (300).>\n" +
                    "<0% = miễn phí.>\n" +
                    "Học phí thấp hoặc bằng 0 có thể giảm áp lực bỏ học, nhưng không trực tiếp làm tăng khả năng công dân đăng ký học."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.FreeSchools)), "Giáo dục miễn phí" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.FreeSchools)),
                    "Đặt tất cả học phí giáo dục về 0%. Các hộ gia đình có học sinh hoặc sinh viên không phải trả học phí.\n" +
                    "Đây không phải là tiền miễn phí hoặc tiền được tạo ra một cách kỳ diệu.\n" +
                    "Ngân quỹ thành phố mất nguồn thu thông thường từ học phí giáo dục.\n" +
                    "**------------------**\n" +
                    "<100%: học phí mặc định>\n" +
                    "<0%: hộ gia đình không phải trả gì.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetEducationFees)), "Mặc định của trò chơi" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetEducationFees)),
                    "Đưa cả ba thanh trượt học phí về 100% và khôi phục học phí mặc định của trò chơi."
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.NameDisplay)),     "Tên hiển thị của mod này." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.VersionDisplay)), "Phiên bản" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.VersionDisplay)),  "Phiên bản hiện tại của mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenParadoxMods)),  "Mở trang mod của tác giả trên Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenDiscord)),  "Mở Discord cộng đồng trong trình duyệt." },
            };
        }

        public void Unload()
        {
        }
    }
}
