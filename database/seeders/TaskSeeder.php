<?php

namespace Database\Seeders;

use App\Models\Board;
use App\Models\Task;
use Illuminate\Database\Seeder;

class TaskSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        Board::all()->each(function (Board $board) {
            Task::create([
                "title"=> "Tarefa do quadro $board->id",
                "description" => "De boas",
                "board_id" => $board->id,
            ]);
        });
    }
}
