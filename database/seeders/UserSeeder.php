<?php

namespace Database\Seeders;

use App\Models\User;
use Illuminate\Database\Seeder;

class UserSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        User::all()->each(fn(User $user) => User::destroy($user->id));
        User::create([
            "name"=> "Adonis Salamago",
            "email"=> "adonis@contato.com",
            "password"=> bcrypt("12345678"),
        ]);
    }
}
