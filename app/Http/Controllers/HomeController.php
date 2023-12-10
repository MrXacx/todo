<?php

namespace App\Http\Controllers;

use App\Models\User;
use Illuminate\Http\Request;

class HomeController extends Controller
{
    /**
     * Display landing page
     */
    public function index()
    {
        return view("home");
    }
}
