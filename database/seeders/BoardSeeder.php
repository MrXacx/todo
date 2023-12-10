<?php

namespace Database\Seeders;

use App\Models\Board;
use App\Models\User;
use Illuminate\Database\Seeder;

class BoardSeeder extends Seeder
{
	/**
	 * Run the database seeds.
	 */
	public function run(): void
	{
		User::all()->each(function (User $user) {
			Board::create([
				"name" => "Natal",
				"description" => "Só testando de leve",
				"user_id" => $user->id
			]);
		});
	}
}
