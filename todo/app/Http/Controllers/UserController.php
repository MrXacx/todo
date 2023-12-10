<?php

namespace App\Http\Controllers;

use App\Models\User;
use Illuminate\Http\Request;

class UserController extends Controller
{
    /**
     * Display landing page
     */
    public function index(){}

    /**
     * Display sign up page
     */
    public function create(){}

    /**
     * Store a new user
     */
    public function store(Request $request){}

    /** Edit */
    public function edit(User $user){}

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, User $user){}

    /**
     * Remove the user
     */
    public function destroy(User $user){}
}
