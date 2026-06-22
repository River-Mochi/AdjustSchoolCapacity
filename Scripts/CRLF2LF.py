# <copyright file="CRLF2LF.py" company="River-Mochi">
# Copyright (c) 2026 River-Mochi. All rights reserved.
# Licensed under the MIT License. You may not use this file except in compliance with this License.
# See LICENSE file in the project root for full license information.
# This notice and the MIT License notice must be kept with
# all copies or substantial portions of this code.
# ================= </copyright> ======================

# File: RoadRailSpeeds/Scripts/CRLF2LF.py
# Purpose: Convert common tracked text files from CRLF/mixed endings to LF.

from pathlib import Path


TEXT_EXTENSIONS = {
    ".cs",
    ".csproj",
    ".xml",
    ".json",
    ".tsx",
    ".ts",
    ".css",
    ".md",
    ".ps1",
    ".props",
    ".targets",
    ".slnx",
    ".editorconfig",
    ".gitattributes",
    ".gitignore",
}

SKIP_PARTS = {
    ".git",
    ".vs",
    "bin",
    "obj",
    "node_modules",
}


for path in Path(".").rglob("*"):
    if not path.is_file():
        continue

    if any(part in SKIP_PARTS for part in path.parts):
        continue

    if path.suffix.lower() not in TEXT_EXTENSIONS and path.name not in TEXT_EXTENSIONS:
        continue

    data = path.read_bytes()
    if b"\0" in data:
        continue

    new_data = data.replace(b"\r\n", b"\n").replace(b"\r", b"\n")
    if new_data != data:
        path.write_bytes(new_data)
        print(path)
