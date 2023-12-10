<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent;

class User extends Model
{
	use HasFactory;

	protected $fillable = ["name", "email", "password", "verified_at"];
	protected $hidden = ["password"];
}
