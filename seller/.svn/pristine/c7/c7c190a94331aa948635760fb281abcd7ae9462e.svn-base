/////////////////////////////////////////////////////////////////////
//
// File: generic-modal-popup.js
// 
// Purpose: This file provides a generic way to popup a modal 
//	    "dialog" style browser window (no toolbars, status bar,
//	    not resizeable, etc.)  Scrollbars are optional.  Although
//	    true modal dialogs are only available in IE for windows,
//	    this code will keep the popup window in front of the 
//	    browser window that opened it, while allowing the user
//	    to switch to other applications.  The openModalDialog
//	    method allows you to specify the URL to open in the 
//	    modal window, the width and height for the window client
//	    area, and what scrollbar options to use.  The window will
//	    be centered on the screen when opened.
//
// Browsers: This code has been tested with the following browsers.  
//           It may work in other browsers, but no guarantees are 
//           made...
//
//           Compatible
//           IE 5.5+ (PC)
//           Netscape 7 (all platforms)
//	     IE 5.1+ (Mac)
//	     Safari
// 
// Author:  Jeremy Baer
//
// Created: 08/20/03
//
// Copyright (c) 2003 Amazon.com
/////////////////////////////////////////////////////////////////////	 

var _modalWindow = null;

/////////////////////////////////////////////////////////////////////
//
// Function: openModalDialog
//
// Purpose: Opens a modal "dialog" style browser window (no toolbars, 
//	    status bar, not resizeable, etc.)  Scrollbars are 
//	    optional.  The modal window will be centered on the
//	    screen and will remain in front of the browser window 
//	    that opened it (disallowing input in the opening window)
//	    while allowing the user to switch focus to other
//	    applications, etc.
//
// Inputs: url		-- string containing the URL to open 
//         w		-- width of the client area of the window
//	   h		-- height of the client area of the window
//	   scrollbarTag	-- string representing the desired scrollbar
//			   options for the window (i.e. 
//			   "scrollbars=no")
//	   nameStr	-- TODO, I don't know I assume the name of the window, 
//			   but this doesn't seem to show up at all.
//	   toolbar	-- if yes, then toolbar, if no then not, if nothing 
//			   then not.
//
// Returns: None.
/////////////////////////////////////////////////////////////////////
function openModalDialog(url, w, h, scrollbarTag, nameStr, toolbar)
{
	if(window.Event) window.top.captureEvents(Event.CLICK|Event.FOCUS);
	window.top.onclick = ignoreEvents;
	window.top.onfocus = focusHandler;

	if (toolbar == null) {
	    toolbar = "no";
	}

	l = (screen.width - w) / 2;
	t = (screen.height - h) / 2;
	_modalWindow = window.open(url, nameStr, 
 		"height="+h+",width="+w+",left="+l+",top="+t+
 		",status=no,toolbar="+toolbar+",menubar=no,location=no,resizable=yes," + scrollbarTag);	
	_modalWindow.window.focus();
}


// private methods that make the modal-ness of the window happen
function ignoreEvents(e)
{
        if(_modalWindow)
        {
                if(!_modalWindow.closed)
                {
	                return false;
                }
        }
        return true;
}

function focusHandler()
{
	if(_modalWindow) 
	{
		if(!_modalWindow.closed)
		{
			_modalWindow.focus();
		}
		else
		{
			if(window.Event) window.top.releaseEvents(Event.CLICK|Event.FOCUS);
			window.top.onclick = "";
			window.top.onfocus = "";
		}
	}
}


/////////////////////////////////////////////////////////////////////
//
// Function: openNonModalDialog
//
// Purpose: Conveniece function for opening a window using same args
//          as openModalDialog, but with no attemp to be modal.  Good
//          for help popups, etc.
//
// Inputs: url		-- string containing the URL to open 
//         w		-- width of the client area of the window
//	   h		-- height of the client area of the window
//	   scrollbarTag	-- string representing the desired scrollbar
//			   options for the window (i.e. 
//			   "scrollbars=no")
//	   nameStr	-- TODO, I don't know I assume the name of the window, 
//			   but this doesn't seem to show up at all.
//	   toolbar	-- if yes, then toolbar, if no then not, if nothing 
//			   then not.
//
// Returns: None.
/////////////////////////////////////////////////////////////////////
function openNonModalDialog(url, w, h, scrollbarTag, nameStr, toolbar)
{
	if (toolbar == null) {
	    toolbar = "no";
	}

	l = (screen.width - w) / 2;
	t = (screen.height - h) / 2;
	window.open(url, nameStr, 
 		"height="+h+",width="+w+",left="+l+",top="+t+
 		",status=no,toolbar="+toolbar+",menubar=no,location=no,resizable=yes," + scrollbarTag);	
}

/////////////////////////////////////////////////////////////////////
//
// Function: helppopup
//
// Purpose: Opens a pop-up window.
//
// Inputs: url		-- string containing the URL to open 
//	   toolbar	-- if yes, then toolbar, if no then not, if nothing 
//			   then not.
//
// Returns: None.
/////////////////////////////////////////////////////////////////////

function helppopup(url, toolbar)
{
	if(window.Event) window.top.captureEvents(Event.CLICK|Event.FOCUS);
	window.top.onclick = ignoreEvents;
	window.top.onfocus = focusHandler;
	
	var w = 725;
	var h = 550;

	if (toolbar == null) {toolbar = "no";}

	l = (screen.width - w) / 2;
	t = (screen.height - h) / 2;
	_modalWindow = window.open(url, null, 
 		"height="+h+",width="+w+",left="+l+",top="+t+
 		",status=no,toolbar="+toolbar+",menubar=no,location=no,resizable=yes,scrollbars=yes");	
	_modalWindow.window.focus();
}